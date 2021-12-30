using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public Text AnyKey;
    void Start()
    {
        AnyKey.enabled = false;
        StartCoroutine(Wait());
    }

    private void Update()
    {
        if (Input.anyKeyDown && AnyKey.enabled)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(30f);
        AnyKey.enabled = true;
    }
}
