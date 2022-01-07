using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    #region 欄位
    public bool PC = true;
    public float Horizontal;
    public JumpButton jumpButton;
    public GameObject MobileJoyStick;
    public GameObject m_inpul_left;
    #region 公開欄位
    public AudioSource audioSource;
    public AudioClip JumpSound;
    public static bool HardMode = false;
    public int Player_LookDirection = 1;
    [Header("玩家血量")]
    public int Player_HP = 5;
    [Header("玩家攻擊力")]
    public int Player_ATK = 1;
    [Header("玩家移動速度")]
    public int Player_MoveSpeed = 5;
    [Header("玩家最大跳躍高度")]
    public int Player_MaxJumpHeigh = 1500;
    [Header("玩家跳躍高度")]
    public float Player_JumpHeigh = 250;
    [Header("玩家跳躍距離")]
    public float Player_JumpDistance = 10;
    public float JumpDistanceMultiply = 90;
    [Header("空白鍵長按時間")]
    [Tooltip("值越小 需要長按的時間越短\n值越大 需要長按的時間越長")] public float HoldTimeMultiply = 750;
    [Header("玩家是否攻擊中")]
    [Tooltip("False 無攻擊，True 攻擊中")] public bool PlayerIsAttacking = false;
    [Header("玩家是否跳躍中")]
    [Tooltip("False 在地面，True 在空中")] public bool PlayerIsJumping = false;
    [Header("Gizmos圓形設定")]
    [Tooltip("圓形半徑")] public float CircleRadius = 0.25f;
    [Tooltip("圓形圓心")] public Vector3 CenterOfCircle;
    [Header("地板圖層")]
    public LayerMask Ground;
    [Header("暫停選單畫布")]
    public GameObject Pause_UI_Canvas;
    public PhysicsMaterial2D WithFriction;    // 有摩擦力的
    public PhysicsMaterial2D NothFriction;    // 无摩擦力的
    public bool HoldSpaceUp = false;
    public float StartHoldSpaceTime;
    public float Player_JumpHeigh_Time;
    public float GameTime;
    public bool InputEnabled = true;
    #endregion

    #region 私人欄位
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    #endregion

#endregion

    #region 方法

    public void CheckGround() /*偵測是否離開地面，如果在地面上 設定PlayerIsJumping為 False，如果在空中 設定PlayerIsJumping為 True*/
    {
        Collider2D isGround = Physics2D.OverlapCircle(transform.position + CenterOfCircle, CircleRadius, Ground);
        PlayerIsJumping = !isGround;
    }

    public void Player_Jumping () /*玩家跳躍判斷函數*/
    {
        if (HoldSpaceUp)
        {
            if (HardMode)
            {
                Player_JumpDistance = Player_LookDirection * Player_JumpHeigh / JumpDistanceMultiply;
                Debug.Log(Player_JumpDistance);
                rb.AddForce(new Vector2(Player_JumpDistance, Player_JumpHeigh));
            }
            else
            {
                rb.AddForce(new Vector2(0, Player_JumpHeigh));
            }
        }
        if (PlayerIsJumping)
        {
            animator.SetBool("Jump_Bool", true);
            rb.sharedMaterial = NothFriction;
        }
        else if (!PlayerIsJumping)
        {
            animator.SetBool("Jump_Bool", false);
            rb.sharedMaterial = WithFriction; 
            HoldSpaceUp = false;
        }
    }

    public void Player_HoldSpace() /*玩家長按空白鍵判斷函數，Player_JumpHeigh_Time 為長按空白鍵時間，Player_JumpHeigh 為計算後的跳躍高度*/
    {
        if (!PlayerIsJumping &&  (Input.GetButtonDown("Jump") || jumpButton.ButtonDownBool))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            StartHoldSpaceTime = GameTime;
            animator.SetBool("HoldSpace_Bool", true);
        }

        if (!PlayerIsJumping &&   (Input.GetButtonUp("Jump") || jumpButton.ButtonUpBool))
        {
            Player_JumpHeigh_Time = GameTime - StartHoldSpaceTime;
            Player_JumpHeigh = (GameTime - StartHoldSpaceTime) * HoldTimeMultiply; /*(按下空白鍵時間 加 鬆開空白鍵的時間) 乘  HoldTimeMultiply*/
            if (Player_JumpHeigh <= Player_MaxJumpHeigh)
            {
                HoldSpaceUp = true;
            }
            else if (Player_JumpHeigh > Player_MaxJumpHeigh)
            {
                Player_JumpHeigh = Player_MaxJumpHeigh;
                HoldSpaceUp = true;
            }
            PlaySound(JumpSound);
            animator.SetBool("HoldSpace_Bool", false);
        }
    }

    public void Player_Attacking () /*玩家攻擊函數*/
    {
        //if (Input.GetButton("Fire1") && PlayerIsAttacking == false)
        //{
        //    PlayerIsAttacking = true;
        //    print("攻擊");
        //    animator.SetTrigger("Attack_Trigger");
        //    Invoke("SetAttacking", 1);
        //}
    }
    void SetAttacking() { PlayerIsAttacking = false; }

    public void Player_GetHurt () /*玩家受傷函數*/
    {
        animator.SetTrigger("Hurt_Trigger");
        Player_HP--;
        if (Player_HP <= 0)
        {
            print("呼叫玩家死亡場景");
            animator.SetBool("Die_Bool", true);
            Invoke("SetScene", 3);
        }
    }
    void SetScene() { SceneManager.LoadScene("GameOver"); }

    public void Player_Move_Ctrl () /*玩家移動控制函數，如果長按空白鍵中則不移動*/
    {
        if (InputEnabled)
        {
            if (!HardMode)
            {
                if (PC)
                {
                    Horizontal = Input.GetAxis("Horizontal");
                }
                else
                {
                    Horizontal = m_inpul_left.GetComponent<MobileInputController>().Horizontal;
                }
            }
            else if (HardMode)
            {
                if (!PlayerIsJumping)
                {
                    if (PC)
                    {
                        Horizontal = Input.GetAxis("Horizontal");
                    }
                    else
                    {
                        Horizontal = m_inpul_left.GetComponent<MobileInputController>().Horizontal;
                    }
                }
            }
        }


        if (!animator.GetBool("HoldSpace_Bool"))
        {
            rb.velocity = new Vector2(Horizontal * Player_MoveSpeed, rb.velocity.y);
        }
            
        if (Horizontal < 0)
        {
            sr.flipX = true;
            Player_LookDirection = -1;
            animator.SetBool("Walk_Bool", true);
        }
        else if (Horizontal > 0)
        {
            sr.flipX = false;
            Player_LookDirection = 1;
            animator.SetBool("Walk_Bool", true);
        }
        else { Player_LookDirection = 0; animator.SetBool("Walk_Bool", false); }
    }

    public void Game_Pause() /*暫停選單函數*/
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Pause_UI_Canvas.activeSelf == true)
            {
                Pause_UI_Canvas.SetActive(false);
                Time.timeScale = 1;
                print("關閉暫停選單");
            }
            else
            {
                Pause_UI_Canvas.SetActive(true);
                Time.timeScale = 0;
                print("開啟暫停選單");
            }
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    #endregion

    #region Unity 事件
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + CenterOfCircle, CircleRadius);
    }
    void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            PC = false;
            MobileJoyStick.SetActive(true);
        }
        else
        {
            PC = true;
            MobileJoyStick.SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Pause_UI_Canvas.SetActive(false);
        InputEnabled = true;
    }
    void Update()
    {
        CheckGround();
        Game_Pause();
        Player_HoldSpace();
        Player_Attacking();
        GameTime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        Player_Move_Ctrl();
        Player_Jumping();
    }
    #endregion

}
