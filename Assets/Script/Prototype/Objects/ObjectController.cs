using UnityEngine;

// Extends the player controller class to be controllable
public class ObjectController : PlayerController
{
    public ColorManager colorMgr;
    public Transform PlayerLeavePoint { get; private set; }
    public PlayerController Player { get; set; }

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            Player.ControlObject(this, false, Player);
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
        else
        {
            return;
        }
    }
}
