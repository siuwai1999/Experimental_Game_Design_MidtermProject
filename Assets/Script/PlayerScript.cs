using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Animator animator;

    [Header("���a��q"),Range(0,5)]
    public int Player_HP = 5;

    [Header("���a�����O"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("���a���ʳt��"), Range(1, 10)]
    public int Player_MoveSpeed = 5;

    [Header("���a���D����")]
    public int Player_JumpHeigh = 250;

    [Header("���a�O�_������")]
    public bool PlayerIsAttacking = false;
    
    [Header("���a�O�_���D��")]
    public bool PlayerIsJumping = false;

    public float RoundSize = 0.8f;
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

    public void CheckGround()
    {
        Collider2D Hit = Physics2D.OverlapCircle(transform.position + Round, RoundSize, Ground);
        PlayerIsJumping = Hit;
    }

    public void Player_Jumping () /*���a���D�P�_���*/
    {
        if(PlayerIsJumping && Input.GetButton("Jump"))
        {
            animator.SetBool("Jump_Bool", PlayerIsJumping);
            Rigi.AddForce(new Vector2(0, Player_JumpHeigh));
        }
        else 
        {
            animator.SetBool("Jump_Bool", !PlayerIsJumping);
        }
    }


    public void Player_Attacking () /*���a�������*/
    {
        if (PlayerIsAttacking == false)
        {
            PlayerIsAttacking = true;
            if (PlayerIsJumping == true)
            {
                print("�a������");
                animator.SetTrigger("Attack_Trigger");
            }
            Invoke("SetAttacking", 1);
        }
    }

    void SetAttacking() { PlayerIsAttacking = false; }

    public void Check_Player_HP () /*���a��q�P�_*/
    {
        if (Player_HP == 0)
        {
            print("�I�s���a���`����");
            bool Death = true;
            animator.SetBool("Die_Bool", Death);
            Invoke("SetScene", 3);
        }
    }

    void SetScene() { SceneManager.LoadScene("GameOver"); }

    public void Player_GetHurt () /*���a���˨��*/
    {
        print("�I�s���a���˰ʵe");
        Player_HP--;
        Check_Player_HP();
    }

    public void Game_Pause () /*�Ȱ������*/
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Pause_UI_Canvas.activeSelf == true)
            {
                Pause_UI_Canvas.SetActive(false);
                print("�����Ȱ����");
            }
            else
            {
                Pause_UI_Canvas.SetActive(true);
                print("�}�ҼȰ����");
            }
        }
    }

    public void Player_Move_Ctrl () /*���a���ʱ�����*/
    {
        //Vector2 Player_Move = transform.position;
        //Player_Move.x = Player_Move.x + Input.GetAxis("Horizontal") * Player_MoveSpeed / 300;
        //transform.position = Player_Move;

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
        else
        {
            bool Horizontal_Move = false;
            animator.SetBool("Walk_Bool", Horizontal_Move);
        }

    }

    
    void Start ()
    {
        print("����C���]�p3A �t�|���v���Ѻ� \n 108051864_�����m  108051044_���t�e  108051730_�L���J");
        Pause_UI_Canvas.SetActive(false);
        animator = GetComponent<Animator>();
        Sprite = GetComponent<SpriteRenderer>();
        Rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Game_Pause();
        CheckGround();
        Player_Jumping();
    }

    private void FixedUpdate()
    {
        Player_Move_Ctrl();
    }

}
