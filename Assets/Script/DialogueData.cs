using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Data")]

public class DialogueData : ScriptableObject
{
    [Header("對話內容"),TextArea(3,5)]
    public string[] Dialogue;
}
