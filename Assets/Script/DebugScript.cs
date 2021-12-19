using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public GameObject DebugWindows;
    public PlayerScript playerScript;
    public GameTimer gameTimer;
    public TrailRenderer trailRenderer;
    public Text Mode;
    public Text LookDirection;
    public Text HoldTime;
    public Text JumpHeigh;
    public Text Jump;
    public Text Trail;

    // Start is called before the first frame update
    void Start()
    {
        DebugWindows.SetActive(false);
        trailRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (DebugWindows.activeSelf)
            {
                DebugWindows.SetActive(false);
                trailRenderer.enabled = false;
            }
            else
            {
                DebugWindows.SetActive(true);
                trailRenderer.enabled = true;
            }
        }

        if (DebugWindows.activeSelf)
        {
            Mode.text = "困難模式:" + playerScript.HardMode.ToString() ;
            LookDirection.text = "方向:" + playerScript.Player_LookDirection.ToString();
            if (Input.GetButton("Jump") && !playerScript.PlayerIsJumping)
            {
                HoldTime.text = "長按持間:" + (playerScript.GameTime - playerScript.StartHoldSpaceTime).ToString();
                float JumpHeigh_Temp = (playerScript.GameTime - playerScript.StartHoldSpaceTime) * playerScript.HoldTimeMultiply;
                if (JumpHeigh_Temp > playerScript.Player_MaxJumpHeigh)
                {
                    JumpHeigh_Temp = playerScript.Player_MaxJumpHeigh;
                }
                JumpHeigh.text = "跳躍高度:" + (int)JumpHeigh_Temp;
            }
            Jump.text = "跳躍次數:" + gameTimer.Jump.ToString();
            Trail.text = "軌跡渲染:" + trailRenderer.enabled;
        }
    }
}   
