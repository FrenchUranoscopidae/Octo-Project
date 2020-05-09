using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ColorManager colorMgr;
    public PlayerController controller;
    public GameObject smoke;
    public Texture alienYellowTexture;
    public Texture alienMagentaTexture;

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
        if (col.CompareTag("ColorSwap"))
        {
            ColorChanger changer = collision.collider.GetComponent<ColorChanger>();
            changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors
        }
        else if (col.CompareTag("ControllableHeavy"))
        {
            ObjectController obj = col.GetComponent<ObjectController>();
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor()) // If the player has the same color than the object
            {
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
                Instantiate(smoke, obj.transform.position, obj.transform.rotation);
                controller.ControlObject(obj, true, controller);
                Destroy(GameObject.Find("VFX Smoke(Clone)"), 2f);
            }
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