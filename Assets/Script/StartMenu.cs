using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator GameTitle;
    public Animator ModeSelect;

    private void Start()
    {
        Time.timeScale = 1;

    }
    public void StartGame()
    {
        GameTitle.SetBool("Click",true);
        ModeSelect.SetBool("Click",true);
    }
}
