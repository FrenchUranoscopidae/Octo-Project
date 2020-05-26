using TreeEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Components
    protected Rigidbody rb;

    // Attributes (protected to be accessed from child classes)
    [SerializeField] public bool isControlled = true;
    [SerializeField] protected float xSpeed = 15f;
    [SerializeField] public int weight;
    public GameObject footstep;
    private Animator alienAnimation;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    public float gravity = 8.91f;
    public CharacterController controller;

    // This method is protected to be accessed from child classes and virtual to be overriden in child classes
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        alienAnimation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {

        if (isControlled)       
        {
            // Get the horizontal axis value and scale it by time and speed (used for player rotation)
            float horizontal = Input.GetAxisRaw("Horizontal")   ;
            // Get the vertical axis value and scale it by time and speed (used for player translation)
            float vertical = Input.GetAxisRaw("Vertical");

            //Apply Movement
            Vector3 direction = new Vector3(vertical, 0f, horizontal).normalized;
            transform.TransformDirection(direction);
            
            //Apply gravity
            direction.y -= gravity * Time.deltaTime;
            controller.Move(direction * Time.deltaTime);

            //Apply rotation
            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                controller.Move(direction * xSpeed * Time.deltaTime);
            }

            //Play Sound and animation
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                alienAnimation.SetTrigger("isWalking"); 
                PlayFootstepSound();
            }
            else
            {
                StopPlayFootstepSound();
            }
        }
    }

    private void Move(float horizontal, float vertical)
    {
        /*transform.Rotate(new Vector3(0f, horizontal, 0f)); // Rotate arround the Y axis
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f); // Constraint the rotation
        rb.MovePosition(rb.position + transform.forward * vertical); // Move along the player forward
        transform.Translate(vertical / 5, 0f, horizontal / 5);*/
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
            player.GetComponent<SkinnedMeshRenderer>().enabled = false;
            objToControl.SetIsControlled(true);
            player.SetIsControlled(false);
            player.GetComponent<BoxCollider>().enabled = false;
            controller.enabled = false;
            player.transform.parent = objToControl.transform;
            player.GetComponent<Rigidbody>().isKinematic = true;
            StopPlayFootstepSound(); 
        }
        else
        {
            player.GetComponent<SkinnedMeshRenderer>().enabled = true;
            objToControl.SetIsControlled(false);
            player.SetIsControlled(true);
            player.transform.parent = null;
            player.transform.position = objToControl.PlayerLeavePoint.position;
            player.GetComponent<BoxCollider>().enabled = true;
            controller.enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            objToControl.Player = null;
        }
    }

    public void PlayFootstepSound()
    {
        footstep.GetComponent<AudioSource>().enabled = true;
        footstep.GetComponent<AudioSource>().loop = true;
    }

    public void StopPlayFootstepSound()
    {
        footstep.GetComponent<AudioSource>().enabled = false;
        footstep.GetComponent<AudioSource>().loop = false;
    }
}   