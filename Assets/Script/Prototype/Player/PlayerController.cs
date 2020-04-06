using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    protected Rigidbody rb;

    // Attributes (protected to be accessed from child classes)
    [SerializeField] public bool isControlled = true;
    [SerializeField] protected float xSpeed = 15f;
    [SerializeField] protected float zSpeed = 100f;
    [SerializeField] public int weight;

    // This method is protected to be accessed from child classes and virtual to be overriden in child classes
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (isControlled)
        {
            // Get the horizontal axis value and scale it by time and speed (used for player rotation)
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * xSpeed;
            // Get the vertical axis value and scale it by time and speed (used for player translation)
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * zSpeed;
            // Apply the movement
            Move(horizontal, -vertical);
        }
    }

    private void Move(float horizontal, float vertical)
    {
        /*transform.Rotate(new Vector3(0f, horizontal, 0f)); // Rotate arround the Y axis
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f); // Constraint the rotation
        rb.MovePosition(rb.position + transform.forward * vertical); // Move along the player forward*/
        transform.Translate(vertical / 5, 0, 0);
        transform.Translate(0, 0, horizontal / 5);
    }

    public void SetIsControlled(bool val)
    {
        isControlled = val;
    }

    public void ControlObject(ObjectController objToControl, bool controlObject, PlayerController player)
    {
        if (player == null || objToControl == null) return;

        if (controlObject)
        {
            objToControl.Player = player;
            player.GetComponent<MeshRenderer>().enabled = false;
            objToControl.SetIsControlled(true);
            player.SetIsControlled(false);
            player.GetComponent<Collider>().enabled = false;
            player.transform.parent = objToControl.transform;
            player.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            player.GetComponent<MeshRenderer>().enabled = true;
            objToControl.SetIsControlled(false);
            player.SetIsControlled(true);
            player.transform.parent = null;
            player.transform.position = objToControl.PlayerLeavePoint.position;
            player.GetComponent<Collider>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            objToControl.Player = null;

        }
    }
}