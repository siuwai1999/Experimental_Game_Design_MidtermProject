using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [Header("���a��q"),Range(1,5)]
    public int Player_HP = 5;

    [Header("���a�����O"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("���a���ʳt��"), Range(1, 10)]
    public int Player_MoveSpeed = 5;

    [Header("���a�O�_������")]
    public bool PlayerIsAttacking = false;
    
    [Header("���a�O�_���D��")]
    public bool PlayerIsJumping = false;


    public void Player_Jumping () /*���a���D�P�_���*/
    {
        if(PlayerIsJumping == false)
        {
            PlayerIsJumping = true;
            print("�եΪ��a���D�ʵe");
            PlayerIsJumping = false;
        }
    }

    public void Player_Attacking () /*���a�������*/
    {
        if (PlayerIsAttacking == false)
        {
            PlayerIsAttacking = true;
            if (PlayerIsJumping == false)
            {
                print("�a������");
            }
            else
            {
                print("�Ť�����");
            }
            PlayerIsAttacking = false;
        }
    }

    public void Player_Die () /*���a���`���*/
    {
        print("�եΪ��a���`����");
        SceneManager.LoadScene("GameOver");
    }

    public void Check_Player_HP () /*���a��q�P�_*/
    {
        if (Player_HP == 0)
        {
            Player_Die();
        }
    }

    public void Player_GetHurt () /*���a���˨��*/
    {
        print("�եΪ��a���˰ʵe");
        Player_HP--;
        Check_Player_HP();
    }

    void Start ()
    {
        print("����C���]�p3A �t�|���v���Ѻ� \n 108051864_�����m  108051044_���t�e  108051730_�L���J");
    }

    void Update()
    {
        Vector2 Player_Move = transform.position;
        Player_Move.x = Player_Move.x + Input.GetAxis("Horizontal") * Player_MoveSpeed / 150;
        transform.position = Player_Move;
    }

}
