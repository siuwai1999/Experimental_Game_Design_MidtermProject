using UnityEngine;

public class RandomDiaogue : MonoBehaviour
{
    public DialogueData dialogueData;
    public DialogueRandomSystem dialogueSystem;
    public int random;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            random = Random.Range(0, dialogueData.Dialogue.Length);  
            dialogueSystem.PlayerEnter(dialogueData.Dialogue[random]);
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
