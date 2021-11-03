using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [Header("���a��q"),Range(1,10)]
    public int Player_HP = 5;

    [Header("���a�����O"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("���a���ʳt��"), Range(1, 10)]
    public int Player_SPEED = 1;

    [Header("���a�O�_�Ĩ뤤")]
    public bool PlayerIsSprinting = false;

    [Header("���a�O�_������")]
    public bool PlayerIsAttacking = false;
    
    [Header("���a�O�_���D��")]
    public bool PlayerIsJumping = false;

    public void Player_Sprinting() /*���a�Ĩ���*/
    {
        PlayerIsSprinting = true;
        Player_SPEED = Player_SPEED * 2;
        print("���a�Ĩ뤤");
        Player_SPEED = Player_SPEED / 2;
        PlayerIsSprinting = false;
    }

    public void Player_Jumping () /*���a���D�P�_���*/
    {
        if(PlayerIsJumping == false)
        {
            PlayerIsJumping = true;
            print("�I�s���a���D�ʵe");
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
                //�a�������ʵe
            }
            else
            {
                print("�Ť��T�����");
                //�ΪŤ������ʵe
            }
            PlayerIsAttacking = false;
        }
    }

    public void Player_Die () /*���a���`���*/
    {
        print("�I�s���a���`�ʵe");
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
        Player_HP--;
        Check_Player_HP();
    }

    void Start ()
    {
        print("����C���]�p3A �t�|���v���Ѻ� \n 108051864_�����m  108051044_���t�e  108051730_�L���J");
    }

}
