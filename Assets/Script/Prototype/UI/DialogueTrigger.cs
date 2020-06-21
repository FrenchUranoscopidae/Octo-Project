using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //call "Dialogue" class
    public Dialogue dialogue;

    public void Update()
    {
        //TriggerDialogue();
    }

    //find "DialogueManager" then call function "StartDialogue"
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
