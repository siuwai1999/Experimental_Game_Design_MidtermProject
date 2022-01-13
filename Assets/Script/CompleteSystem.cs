using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteSystem : MonoBehaviour
{
    public Camera ZoomCam;
    public PlayerScript playerScript;
    public GameObject Complete_UI_Canvas;
    public GameTimer GameTimer;
    public Text Timer;
    public Text Jump;
    public Text AnyKey;
    public AudioSource audioSource;

    void Start()
    {
        Complete_UI_Canvas.SetActive(false);
        AnyKey.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.anyKeyDown && Complete_UI_Canvas.activeSelf && AnyKey.enabled)
        {
            SceneManager.LoadSceneAsync(2);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            playerScript.InputEnabled = false;
            playerScript.Horizontal = 0;
            StartCoroutine(Zoom());
        }
    }
    IEnumerator Zoom()
    {
        for (float i = ZoomCam.orthographicSize; i > 4; i-= 0.05f)
        {
            ZoomCam.orthographicSize= i;
            yield return new WaitForSeconds(0.025f);
        }
        yield return new WaitForSeconds(1f);
        Complete_UI_Canvas.SetActive(true);
        Timer.text = "通關用時：" + GameTimer.Timer.text;
        Jump.text = "跳躍次數：" + GameTimer.Jump.ToString();
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(6f);
        AnyKey.enabled = true;
    }
}
