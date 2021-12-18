using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public PlayerScript playerScript;
    public void NormalMode()
    {
        playerScript.HardMode = false;
        SceneManager.LoadSceneAsync(1);
    }
    public void HardMode()
    {
        playerScript.HardMode = true;
        SceneManager.LoadSceneAsync(1);
    }
}
