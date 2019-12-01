using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;


    void Start()
    {
        StartCoroutine(dialogueTriggers());
    }

    IEnumerator dialogueTriggers()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<DialoogueManager>().StartDialogue(dialogue);
    }
}
