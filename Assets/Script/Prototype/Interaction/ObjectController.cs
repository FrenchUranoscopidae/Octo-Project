using UnityEngine;

// Extends the player controller class to be controllable
public class ObjectController : PlayerController
{
    public ColorManager colorMgr;
    public Transform PlayerLeavePoint { get; private set; }
    public PlayerController Player { get; set; }
    public GameObject smoke;

    // override the player controller start method
    protected override void Start()
    {
        base.Start(); // Call the player controller start
        colorMgr.Initialize(GetComponent<MeshRenderer>());
        PlayerLeavePoint = transform.GetChild(0);
        isControlled = false; // Disable controls for this object
    }

    protected override void Update()
    {
        if (!isControlled) return;
        base.Update();

        ObjectController obj = this.GetComponent<ObjectController>();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(smoke, obj.transform.position, obj.transform.rotation);
            Player.ControlObject(this, false, Player);
            Destroy(GameObject.Find("VFX Smoke(Clone)"), 2f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.CompareTag("ColorSwap"))
        {
            ColorChanger changer = collision.collider.GetComponent<ColorChanger>();
            changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors
            Player.GetComponent<PlayerManager>().colorMgr.SetCurrentColor(colorMgr.GetCurrentColor()); // Update the player color
        }
        else if (collision.gameObject.CompareTag("Barrier"))
        {
            BarrierController barrier = col.GetComponent<BarrierController>();
            BoxCollider barrierCollider = col.GetComponent<BoxCollider>();
            if (barrier.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
            else
            {
                barrierCollider.enabled = true;
            }
        }
        else
        {
            return;
        }
    }
}
