using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text Timer;
    public float Time_f;
    public int Time_i;
    public int Second;
    public int Minute;
    public int hour;

    public void Calculate()
    {
        Second = Time_i % 60;
        Minute = Time_i / 60;
        hour = Minute / 60;
    }

    void Start()
    {
        Timer = GetComponent<Text>();
    }


    void Update()
    {
        Time_f = Time.deltaTime;
        Time_i =(int)Time.time;
        Calculate();
        if (hour < 1)
        {
            if (Minute < 10)
            {
                if (Second < 10)
                {
                    Timer.text = "0" + Minute.ToString() + ":" + "0" +Second.ToString();
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
