using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDiaogue : MonoBehaviour
{
    public DialogueData dialogueData;
    public DialogueSystem dialogueSystem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            dialogueSystem.PlayerEnter(dialogueData.Dialogue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogueSystem.PlayerExit();
        }
    }
}
