using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    public void ExitGame() 
    {
        print("退出遊戲");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void StartGame()
    {
        print("開始遊戲");
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        print("返回標題");
        SceneManager.LoadScene("MainMenu");
    }

}
