using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public PlayerScript PlayerScript;
    public GameObject GameTitle;
    public GameObject ModeSelect;

    private void Start()
    {
        GameTitle.SetActive(true);
        ModeSelect.SetActive(false);
    }
    public void StartGame()
    {
        GameTitle.SetActive(false);
        ModeSelect.SetActive(true);
    }

    public void NormalMode()
    {
        PlayerScript.HardMode = false;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void HardMode()
    {
        PlayerScript.HardMode = true;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
}
