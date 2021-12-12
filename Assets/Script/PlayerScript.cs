using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    #region 欄位

        #region 公開欄位
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
        [Header("計時器")]
        public Text Timer;
        public PhysicsMaterial2D WithFriction;    // 有摩擦力的
        public PhysicsMaterial2D NothFriction;    // 无摩擦力的
    #endregion

    #region 私人欄位
        private bool HoldSpaceUp = false;
        private float StartHoldSpaceTime;
        private float Player_JumpHeigh_Time;
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
            rb.AddForce(new Vector2(0, Player_JumpHeigh));
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
        if (!PlayerIsJumping && Input.GetButtonDown("Jump"))
        {
            StartHoldSpaceTime = Time.time;
            animator.SetBool("HoldSpace_Bool", true);
        }

        if (!PlayerIsJumping && Input.GetButtonUp("Jump"))
        {
            Player_JumpHeigh_Time = Time.time - StartHoldSpaceTime;
            Player_JumpHeigh = (Time.time - StartHoldSpaceTime) * HoldTimeMultiply; /*(按下空白鍵時間 加 鬆開空白鍵的時間) 乘  HoldTimeMultiply*/
            if (Player_JumpHeigh <= Player_MaxJumpHeigh)
            {
                HoldSpaceUp = true;
            }
            else if (Player_JumpHeigh > Player_MaxJumpHeigh)
            {
                Player_JumpHeigh = Player_MaxJumpHeigh;
                HoldSpaceUp = true;
            }
            animator.SetBool("HoldSpace_Bool", false);
            print("跳躍高度" + Player_JumpHeigh + "長按時間(秒)" + Player_JumpHeigh_Time);
        }
    }

    public void Player_Attacking () /*玩家攻擊函數*/
    {
        if (Input.GetButton("Fire1") && PlayerIsAttacking == false)
        {
            PlayerIsAttacking = true;
            print("地面攻擊");
            animator.SetTrigger("Attack_Trigger");
            Invoke("SetAttacking", 1);
        }
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
        if (!animator.GetBool("HoldSpace_Bool"))
        {
            float Horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(Horizontal * Player_MoveSpeed, rb.velocity.y);

            if (Horizontal < 0)
            {
                sr.flipX = true;
            }
            else if (Horizontal > 0)
            {
                sr.flipX = false;
            }

            if (Horizontal != 0)
            {
                animator.SetBool("Walk_Bool", true);
            }
            else
            {
                animator.SetBool("Walk_Bool", false);
            }
        }
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

    #endregion

    #region Unity 事件
    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + CenterOfCircle, CircleRadius);
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Pause_UI_Canvas.SetActive(false);
    }
    void Update()
    {
        CheckGround();
        Game_Pause();
        Player_HoldSpace();
        Player_Attacking();
        Timer.text = Time.time.ToString();
    }
    private void FixedUpdate()
    {
        Player_Move_Ctrl();
        Player_Jumping();
    }
    #endregion

}
