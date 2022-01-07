using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelect : MonoBehaviour
{
    public void NormalMode()
    {
        PlayerScript.HardMode = false;
        SceneManager.LoadSceneAsync(1);
    }
    public void HardMode()
    {
        PlayerScript.HardMode = true;
        SceneManager.LoadSceneAsync(1);
    }
}
