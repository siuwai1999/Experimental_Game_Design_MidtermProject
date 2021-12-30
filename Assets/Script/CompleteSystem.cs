using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteSystem : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject Complete_UI_Canvas;
    public GameTimer GameTimer;
    public Text Timer;
    public Text Jump;
    public Text AnyKey;
    void Start()
    {
        Complete_UI_Canvas.SetActive(false);
        AnyKey.enabled = false;
    }

    void Update()
    {
        if (Input.anyKeyDown && Complete_UI_Canvas.activeSelf && AnyKey.enabled)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Complete_UI());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.Horizontal = 0;
            playerScript.InputEnabled = false;
        }
    }

    IEnumerator Complete_UI()
    {
        yield return new WaitForSeconds(1.5f);
        Complete_UI_Canvas.SetActive(true);
        Timer.text = "通關用時：" + GameTimer.Timer.text;
        Jump.text = "跳躍次數：" + GameTimer.Jump.ToString();
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        AnyKey.enabled = true;
    }
}
