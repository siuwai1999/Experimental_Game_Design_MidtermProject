using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueRandomSystem : MonoBehaviour
{
    [Header("速度"), Range(0, 1)]
    public float TextSpeed = 0.25f;
    [Header("Text_UI_Canvas")]
    public GameObject Text_UI_Canvas;
    [Header("Text_UI")]
    public Text Text_UI;
    public GameObject Tips;
    public KeyCode Next = KeyCode.Space;

    void Start()
    {
        Text_UI_Canvas.SetActive(false);
        //StartCoroutine(TextEffect());
    }

    private IEnumerator TextEffect(string Contents)
    {
        //string DialogueText1 = "123123";
        //string DialogueText2 = "文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。";
        //string[] Contents = { DialogueText1, DialogueText2 };

        Text_UI_Canvas.SetActive(true);
        Text_UI.text = "";
        for (int i = 0; i < Contents.Length; i++)
        {
            Tips.SetActive(false);
            Text_UI.text += Contents[i];
            yield return new WaitForSeconds(TextSpeed);
            Tips.SetActive(true);
        }
            while (!Input.GetKeyDown(Next))
            {
                yield return null;
            }
        Text_UI_Canvas.SetActive(false);
    }

    public void PlayerEnter(string Contents)
    {
        StartCoroutine(TextEffect(Contents));
    }
    public void PlayerExit()
    {
        StopAllCoroutines();
        Text_UI_Canvas.SetActive(false);
    }
}
