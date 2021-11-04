using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [Header("玩家血量"),Range(1,5)]
    public int Player_HP = 5;

    [Header("玩家攻擊力"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("玩家移動速度"), Range(1, 10)]
    public int Player_MoveSpeed = 5;

    [Header("玩家是否攻擊中")]
    public bool PlayerIsAttacking = false;
    
    [Header("玩家是否跳躍中")]
    public bool PlayerIsJumping = false;


    public void Player_Jumping () /*玩家跳躍判斷函數*/
    {
        if(PlayerIsJumping == false)
        {
            PlayerIsJumping = true;
            print("調用玩家跳躍動畫");
            PlayerIsJumping = false;
        }
    }

    public void Player_Attacking () /*玩家攻擊函數*/
    {
        if (PlayerIsAttacking == false)
        {
            PlayerIsAttacking = true;
            if (PlayerIsJumping == false)
            {
                print("地面攻擊");
            }
            else
            {
                print("空中攻擊");
            }
            PlayerIsAttacking = false;
        }
    }

    public void Player_Die () /*玩家死亡函數*/
    {
        print("調用玩家死亡場景");
        SceneManager.LoadScene("GameOver");
    }

    public void Check_Player_HP () /*玩家血量判斷*/
    {
        if (Player_HP == 0)
        {
            Player_Die();
        }
    }

    public void Player_GetHurt () /*玩家受傷函數*/
    {
        print("調用玩家受傷動畫");
        Player_HP--;
        Check_Player_HP();
    }

    void Start ()
    {
        print("實驗遊戲設計3A 孤帆遠影畢書盡 \n 108051864_關兆煒  108051044_曾宇寬  108051730_林奎沅");
    }

    void Update()
    {
        Vector2 Player_Move = transform.position;
        Player_Move.x = Player_Move.x + Input.GetAxis("Horizontal") * Player_MoveSpeed / 150;
        transform.position = Player_Move;
    }

}
