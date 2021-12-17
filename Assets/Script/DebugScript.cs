using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public PlayerScript player;
    public Text Mode;
    public Text LookDirection;
    public Text HoldTime;
    public Text JumpHeigh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mode.text = "�x���Ҧ�:" + player.HardMode.ToString() ;
        LookDirection.text = "��V:" + player.Player_LookDirection.ToString();
        if (Input.GetButton("Jump") && !player.PlayerIsJumping)
        {
            HoldTime.text = "��������:" + (player.GameTime - player.StartHoldSpaceTime).ToString();
            float JumpHeigh_Temp = (player.GameTime - player.StartHoldSpaceTime) * player.HoldTimeMultiply;
            if (JumpHeigh_Temp > player.Player_MaxJumpHeigh)
            {
                JumpHeigh_Temp = player.Player_MaxJumpHeigh;
            }
            JumpHeigh.text = "���D����:" + (int)JumpHeigh_Temp;
        }
    }
}   
