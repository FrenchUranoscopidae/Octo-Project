using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider doorCollider;
    public bool doorIsOpen = false;
    public AudioClip doorSound;
    private Animator openDoor;

    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        openDoor = gameObject.GetComponent<Animator>();
        doorCollider.enabled = true;
    }

    void Update()
    {
        if(doorIsOpen == true)
        {
            openDoor.SetBool("openDoor", true); 
            doorCollider.enabled = false;

            //DialogueTriggering
            if (!b_dialogueHappenned)
            {
                ThisObjectDialogueTrigger();
            }
        }
    }

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }

    public void OpenDoor()
    {
        doorIsOpen = true;
        AudioSource.PlayClipAtPoint(doorSound, transform.position);
    }

    public void CloseDoor()
    {
        doorIsOpen = false;
    }
}