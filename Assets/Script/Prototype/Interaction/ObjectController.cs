using UnityEngine;

// Extends the player controller class to be controllable
public class ObjectController : PlayerController
{
    public ColorManager colorMgr;
    public Transform PlayerLeavePoint { get; private set; }
    public PlayerController Player { get; set; }
    public GameObject smoke;

    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    //Animation props
    public Animator animator;
    //public Animation propsWalk;

    // override the player controller start method
    protected override void Start()
    {
        base.Start(); // Call the player controller start
        colorMgr.Initialize(GetComponent<SkinnedMeshRenderer>());
        colorMgr.InitializeObjectRenderer(GetComponent<MeshRenderer>());
        PlayerLeavePoint = transform.GetChild(0);
        isControlled = false; // Disable controls for this object
    }

    protected override void Update()
    {
        if (!isControlled) return;
        base.Update();

        ObjectController obj = this.GetComponent<ObjectController>();

        //DialogueTriggering
        if (!b_dialogueHappenned)
        {
            ThisObjectDialogueTrigger();
        }   

        if (Input.GetKey(KeyCode.E) || Input.GetButton("Button B"))
        {
            Instantiate(smoke, obj.transform.position, obj.transform.rotation);
            Player.ControlObject(this, false, Player);
            Destroy(GameObject.Find("Rework Smoke(Clone)"), 2f);
        }
    }

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ColorSwap"))
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetButton("Button A"))
            {
                ColorChanger changer = other.GetComponent<ColorChanger>();
                changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors
                Player.GetComponent<PlayerManager>().colorMgr.SetCurrentColor(colorMgr.GetCurrentColor()); // Update the player color
            } 
        }
        else
        {
            return;
        }
    }
}
