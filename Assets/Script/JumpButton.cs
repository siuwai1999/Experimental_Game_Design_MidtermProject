using System.Collections;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public bool ButtonDownBool;
    public bool ButtonUpBool;

    public void ButtonDown()
    {
        ButtonDownBool =true;
        StartCoroutine(Wait());
    }

    public void ButtonUp()
    {
        ButtonUpBool = true;
        StartCoroutine(Wait());
    }

    void Start()
    {
        ButtonDownBool = false;
        ButtonUpBool = false;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.005f);
        ButtonDownBool = false;
        ButtonUpBool = false;
    }
}
