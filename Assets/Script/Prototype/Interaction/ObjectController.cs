using UnityEngine;

public class ObjectController : PlayerController
{
    public ColorManager colorMgr;
    public Transform PlayerLeavePoint { get; private set; }
    public PlayerController Player { get; set; }

    public GameObject smoke;
    public GameObject yellowSmoke;
    public GameObject magentaSmoke;
    public PlayerManager player;

    //Introductions DialogueTriggering
    public bool b_dialogueHappenned = false;
    public bool b_dialogueAllowed = false;
    public DialogueTrigger dialogueTrigger;

    //Animation props
    public Animator animator;
    //public Animation propsWalk;

    [Header("Sound")]
    public AudioClip Pos;
    public float volume;

    [Header("Tuto Depos")]
    public GameObject deposTuto;
    public bool hasActivatedDepos = false;

    [Header("Tuto Pos")]
    public GameObject posTuto;
    public bool hasActivatedPos = false;

    // override the player controller start method
    protected override void Start()
    {
        //Tuto Depos
        hasActivatedDepos = false;

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

        ObjectController obj = GetComponent<ObjectController>();

        //DialogueTriggering
        if (!b_dialogueHappenned & b_dialogueAllowed)
        {
            ThisObjectDialogueTrigger();
        }

        //Tuto Depos
        deposTuto.SetActive(true);
        posTuto.SetActive(false);
        hasActivatedDepos = true;

        if (Input.GetKey(KeyCode.E) && isControlled && player.canDepos && !player.canPos)
        {
            player.canPos = true;
            player.canDepos = false;

            AudioSource.PlayClipAtPoint(Pos, transform.position, volume);

            //Tuto Depos
            if (hasActivatedDepos)
            {
                deposTuto.SetActive(false);
            }

            Instantiate(smoke, obj.transform.position, obj.transform.rotation);
            Player.ControlObject(this, false, Player);
            Destroy(GameObject.Find("Rework Smoke(Clone)"), 2f);
            StopPlayFootstepSound();
        }
    }

    public void LateUpdate()
    {
        player = FindObjectOfType<PlayerManager>();
    }

    //Function to trigger the dialogue of this object only once
    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        Debug.Log(b_dialogueHappenned);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag==("Player"))
        {
            posTuto.SetActive(true);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ColorSwap"))
        {
            ObjectController obj = this.GetComponent<ObjectController>();

            if (Input.GetKey(KeyCode.A) && isControlled)
            {
                ColorChanger changer = other.GetComponent<ColorChanger>();
                changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors
                Player.GetComponent<PlayerManager>().colorMgr.SetCurrentColor(colorMgr.GetCurrentColor()); // Update the player color

                if (colorMgr.GetCurrentColor() == ObjectColor.YELLOW)
                {
                    Instantiate(yellowSmoke, obj.transform.position, obj.transform.rotation);
                    Destroy(GameObject.Find("Rework Yellow Smoke(Clone)"), 2f);
                }
                else if (colorMgr.GetCurrentColor() == ObjectColor.MAGENTA)
                {
                    Instantiate(magentaSmoke, obj.transform.position, obj.transform.rotation);
                    Destroy(GameObject.Find("Rework Magenta Smoke(Clone)"), 2f);
                }
            }
        }
        else
        {
            return;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            posTuto.SetActive(false);
        }
    }
}
