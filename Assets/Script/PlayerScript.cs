using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [Header("玩家血量"),Range(1,10)]
    public int Player_HP = 5;

    [Header("玩家攻擊力"), Range(1, 10)]
    public int Player_ATK = 1;

    [Header("玩家移動速度"), Range(1, 10)]
    public int Player_SPEED = 1;

    [Header("玩家是否衝刺中")]
    public bool PlayerIsSprinting = false;

    [Header("玩家是否攻擊中")]
    public bool PlayerIsAttacking = false;
    
    [Header("玩家是否跳躍中")]
    public bool PlayerIsJumping = false;

    public void Player_Sprinting() /*玩家衝刺函數*/
    {
        PlayerIsSprinting = true;
        Player_SPEED = Player_SPEED * 2;
        print("玩家衝刺中");
        Player_SPEED = Player_SPEED / 2;
        PlayerIsSprinting = false;
    }

    public void Player_Jumping () /*玩家跳躍判斷函數*/
    {
        if(PlayerIsJumping == false)
        {
            PlayerIsJumping = true;
            print("呼叫玩家跳躍動畫");
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
                //地面攻擊動畫
            }
            else
            {
                print("空中禁止攻擊");
                //或空中攻擊動畫
            }
            PlayerIsAttacking = false;
        }
    }

    public void Player_Die () /*玩家死亡函數*/
    {
        print("呼叫玩家死亡動畫");
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
        Player_HP--;
        Check_Player_HP();
    }

    void Start ()
    {
        print("實驗遊戲設計3A 孤帆遠影畢書盡 \n 108051864_關兆煒  108051044_曾宇寬  108051730_林奎沅");
    }

}
