using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerBeginningBox : MonoBehaviour
{
    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //DialogueTriggering
            if (!b_dialogueHappenned)
            {
                ThisObjectDialogueTrigger();
            }
        }
    }
}
