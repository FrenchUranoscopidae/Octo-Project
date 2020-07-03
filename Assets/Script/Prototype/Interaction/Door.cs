    using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider doorCollider;
    public bool doorIsOpen = false;
    public AudioClip doorSound;
    public GameObject diodeColor;
    public Light diodeLightColor;
    public bool alreadyPlayed = false;
    private Animator openDoor;

    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public bool b_dialogueAllowed = false;
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

        if (!alreadyPlayed)
        {
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
            alreadyPlayed = true;
        }

        diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        diodeLightColor.color = Color.green;

        //DialogueTriggering
        if (!b_dialogueHappenned & b_dialogueAllowed)
        {
            ThisObjectDialogueTrigger();
        }

    }

    public void CloseDoor()
    {
        doorIsOpen = false;
    }
}