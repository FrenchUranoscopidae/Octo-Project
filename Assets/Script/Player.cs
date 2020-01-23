using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameObject lastCol;

    Material origin;

    Renderer rend;

    Rigidbody rb;

    bool canMove;
    bool isClimbing;
    
    float camoLeft;

    public GameObject ink;
    public Text textCamo;
    public Text textInk;
    public bool camoActive;
    public float CAMO_MAX;
    public int inkCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();

        origin = rend.material;
        canMove = true;
        camoLeft = CAMO_MAX;
    }
    
    void Update()
    {
        float posx = Input.GetAxis("Horizontal");
        float posy = Input.GetAxis("Vertical");

        if (canMove)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;

            transform.Translate(0, 0, posy / 5);
            //transform.Translate(posx / 5, 0, 0);
            transform.Rotate(0, posx, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, 500, 0));
            }

            if (Input.GetKeyDown(KeyCode.LeftAlt) && inkCount > 0)
            {
                GameObject clone;
                clone = Instantiate(ink, transform.position, transform.rotation);

                inkCount--;
            }
        }

        if (isClimbing)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            transform.Translate(0, posy / 5, 0);
            transform.Translate(posx / 5, 0, 0);
        }

        string camoString = camoLeft.ToString("F0");
        textCamo.text = camoString + "s";

        textInk.text = inkCount.ToString();

        if (camoActive)
        {
            camoLeft -= 1 * Time.deltaTime;
        }
        else if (camoLeft < CAMO_MAX)
        {
            camoLeft += 0.6f * Time.deltaTime;
        }

        if(camoLeft > CAMO_MAX)
        {
            camoLeft = CAMO_MAX;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && camoLeft > 0)
        {
            rend.material = lastCol.GetComponent<Renderer>().material;

            canMove = false;
            camoActive = true;
        }

        if (Input.GetKeyUp(KeyCode.Tab) || camoLeft <= 0)
        {
            rend.material = origin;

            canMove = true;
            camoActive = false;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        lastCol = collision.gameObject;

        if (collision.gameObject.CompareTag("Climbable"))
        {
            canMove = false;
            isClimbing = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Climbable"))
        {
            canMove = true;
            isClimbing = false;
        }
    }
}
