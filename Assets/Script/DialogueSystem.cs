using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("速度"), Range(0, 1)]
    public float TextSpeed = 0.5f;
    [Header("Text_UI_Canvas")]
    public GameObject Text_UI_Canvas;
    [Header("Text_UI")]
    public Text Text_UI;

    void Start()
    {
        StartCoroutine(TextEffect());
    }

    private IEnumerator TextEffect()
    {
        string DialogueText = "文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。文字内容，文字内容。";
        Text_UI.text = "";
        Text_UI_Canvas.SetActive(true);
        for (int i = 0; i < DialogueText.Length; i++)
        {
            Text_UI.text += DialogueText[i];
            yield return new WaitForSeconds(TextSpeed);
        }
    }
}
