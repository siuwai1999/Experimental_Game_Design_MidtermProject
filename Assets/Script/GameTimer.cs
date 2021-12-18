using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Text Timer;
    public float Time_f;
    public int Time_i;
    public int Second;
    public int Minute;
    public int hour;
    public int Jump;


    void Start()
    {
        Timer = GetComponent<Text>();
        Jump = 0;
    }
    void Update()
    {
        JumpCounter();
        TimeCounter();
    }

    void JumpCounter() /*跳躍次數計算器*/
    {
        if (Input.GetButtonUp("Jump"))
        {
            Jump++;
        }
    }

    public void Calculate() /*單位換算*/
    {
        Second = Time_i % 60;
        Minute = Time_i / 60;
        hour = Minute / 60;
    }

    void TimeCounter()
    {
        Time_f += Time.deltaTime;
        Time_i = (int)Time_f;
        Calculate();
        if (hour < 1)
        {
            if (Minute < 10)
            {
                if (Second < 10)
                {
                    Timer.text = "0" + Minute.ToString() + ":" + "0" + Second.ToString();
                }
                else
                {
                    Timer.text = "0" + Minute.ToString() + ":" + Second.ToString();
                }
            }
            else
            {
                if (Second < 10)
                {
                    Timer.text = Minute.ToString() + ":" + "0" + Second.ToString();
                }
                else
                {
                    Timer.text = Minute.ToString() + ":" + Second.ToString();
                }
            }
        }
        else
        {
            if (Minute < 10)
            {
                if (Second < 10)
                {
                    Timer.text = hour.ToString() + ":" + "0" + Minute.ToString() + ":" + "0" + Second.ToString();
                }
                else
                {
                    Timer.text = hour.ToString() + ":" + "0" + Minute.ToString() + ":" + Second.ToString();
                }
            }
            else
            {
                if (Second < 10)
                {
                    Timer.text = hour.ToString() + ":" + Minute.ToString() + ":" + "0" + Second.ToString();
                }
                else
                {
                    Timer.text = hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString();
                }
            }
        }
    }

}
