using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Data")]

public class DialogueData : ScriptableObject
{
    [Header("��ܤ��e"),TextArea(3,5)]
    public string[] Dialogue;
}
