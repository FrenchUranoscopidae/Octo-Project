using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ColorManager colorMgr;
    public PlayerController controller;
    public GameObject smoke;
    public Texture alienYellowTexture;
    public Texture alienMagentaTexture;

    [Header("Sound")]
    public AudioClip Pos;
    public float volume;

    void Start()
    {
        // Initialize the color manager with the mesh renderer
        colorMgr.Initialize(GetComponent<SkinnedMeshRenderer>());
        colorMgr.InitializeObjectRenderer(GetComponent<MeshRenderer>());
        controller = GetComponent<PlayerController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.CompareTag("ControllableHeavy"))
        {
            ObjectController obj = col.GetComponent<ObjectController>();
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor()) // If the player has the same color than the object
            {
                //Sound
                AudioSource.PlayClipAtPoint(Pos, transform.position, volume);

                Instantiate(smoke, obj.transform.position, obj.transform.rotation);
                controller.ControlObject(obj, true, controller);
                Destroy(GameObject.Find("VFX Smoke(Clone)"), 2f);
            }
        }
        else if (col.CompareTag("ControllableLightweight"))
        {
            ObjectController obj = col.GetComponent<ObjectController>();
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor()) // If the player has the same color than the object
            {
                //Sound
                AudioSource.PlayClipAtPoint(Pos, transform.position, volume);

                Instantiate(smoke, obj.transform.position, obj.transform.rotation);
                controller.ControlObject(obj, true, controller);
                Destroy(GameObject.Find("VFX Smoke(Clone)"), 2f);
            }
        }
        else
        {
            return;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("ColorSwap"))
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ColorChanger changer = other.GetComponent<ColorChanger>();
                changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors
            }      
        }
    }
}