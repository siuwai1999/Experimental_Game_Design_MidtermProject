using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void ExitGame() 
    {
        print("�h�X�C��");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void StartGame()
    {
        print("�}�l�C��");
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        print("��^���D");
        SceneManager.LoadScene("MainMenu");
    }
    
}
