using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Animator animator;

    [Header("玩家血量"),Range(0,5)]
    public int Player_HP = 5;

    [Header("玩家攻擊力"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("玩家移動速度"), Range(1, 10)]
    public int Player_MoveSpeed = 5;

    [Header("玩家是否攻擊中")]
    public bool PlayerIsAttacking = false;
    
    [Header("玩家是否跳躍中")]
    public bool PlayerIsJumping = false;

    public float RoundSize = 0.25f;
    public Vector3 Round;

    public LayerMask Ground;

    public Rigidbody2D Rigi;

    public SpriteRenderer Sprite;
    public GameObject Pause_UI_Canvas;

    public void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + Round, RoundSize);
    }

    public void Player_Jumping () /*玩家跳躍判斷函數*/
    {
        if(PlayerIsJumping == false)
        {
            PlayerIsJumping = true;
            animator.SetBool("Jump_Bool", PlayerIsJumping);
            print("呼叫玩家跳躍動畫");
            Invoke("SetPlayerIsJumping", 1);
        }
    }

    void SetPlayerIsJumping() { PlayerIsJumping = false;animator.SetBool("Jump_Bool", PlayerIsJumping); }

    public void Player_Attacking () /*玩家攻擊函數*/
    {
        if (PlayerIsAttacking == false)
        {
            PlayerIsAttacking = true;
            if (PlayerIsJumping == false)
            {
                print("地面攻擊");
                animator.SetTrigger("Attack_Trigger");
            }
            else
            {
                print("空中攻擊");
                animator.SetTrigger("Attack2_Trigger");
            }
            Invoke("SetAttacking", 1);
        }
    }

    void SetAttacking() { PlayerIsAttacking = false; }

    public void Check_Player_HP () /*玩家血量判斷*/
    {
        if (Player_HP == 0)
        {
            print("呼叫玩家死亡場景");
            bool Death = true;
            animator.SetBool("Die_Bool", Death);
            Invoke("SetScene", 3);
        }
    }

    void SetScene() { SceneManager.LoadScene("GameOver"); }

    public void Player_GetHurt () /*玩家受傷函數*/
    {
        print("呼叫玩家受傷動畫");
        Player_HP--;
        Check_Player_HP();
    }

    public void Game_Pause () /*暫停選單函數*/
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Pause_UI_Canvas.activeSelf == true)
            {
                Pause_UI_Canvas.SetActive(false);
                print("關閉暫停選單");
            }
            else
            {
                Pause_UI_Canvas.SetActive(true);
                print("開啟暫停選單");
            }
        }
    }

    public void Player_Move_Ctrl () /*玩家移動控制函數*/
    {
        //Vector2 Player_Move = transform.position;
        //Player_Move.x = Player_Move.x + Input.GetAxis("Horizontal") * Player_MoveSpeed / 300;
        //transform.position = Player_Move;

        //if (Input.GetButton("Jump"))
        //{
        //    Player_Jumping();
        //}

        if (Input.GetButton("Fire1"))
        {
            Player_Attacking();
        }

        float Horizontal = Input.GetAxis("Horizontal");
        Rigi.velocity = new Vector2(Horizontal * Player_MoveSpeed, Rigi.velocity.y);

        if (Horizontal < 0)
        {
            Sprite.flipX = true;
        }
        else if (Horizontal > 0)
        {
            Sprite.flipX = false;
        }

        if (Horizontal != 0)
        {
            bool Horizontal_Move = true;
            animator.SetBool("Walk_Bool", Horizontal_Move);
        }
        else if (Horizontal == 0)
        {
            bool Horizontal_Move = false;
            animator.SetBool("Walk_Bool", Horizontal_Move);
        }

    }

    
    void Start ()
    {
        print("實驗遊戲設計3A 孤帆遠影畢書盡 \n 108051864_關兆煒  108051044_曾宇寬  108051730_林奎沅");
        Pause_UI_Canvas.SetActive(false);
        animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Game_Pause();
    }

    private void FixedUpdate()
    {
        Player_Move_Ctrl();
    }

}
