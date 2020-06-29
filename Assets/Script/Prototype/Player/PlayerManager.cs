﻿using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public ColorManager colorMgr;
    public PlayerController controller;
    public GameObject smoke;
    public GameObject yellowSmoke;
    public GameObject magentaSmoke;

    [Header("Texture")]
    public Texture alienYellowTexture;
    public Texture alienMagentaTexture;

    [Header("Sound")]
    public AudioClip Pos;
    public float volume;

    [Header("Checkpoint")]
    public Transform respawnTarget;
    public Vector3 respawnLocation;

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
                AudioSource.PlayClipAtPoint(Pos, transform.position, volume);
                Instantiate(smoke, obj.transform.position, obj.transform.rotation);
                Destroy(GameObject.Find("Rework Smoke(Clone)"), 2f);
                Destroy(GameObject.Find("Rework Smoke(Clone)"), 2f);        
                controller.ControlObject(obj, true, controller);
            }
        }
        else if (col.CompareTag("ControllableLightweight"))
        {
            ObjectController obj = col.GetComponent<ObjectController>();
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor()) // If the player has the same color than the object
            {
                AudioSource.PlayClipAtPoint(Pos, transform.position, volume);
                Instantiate(smoke, obj.transform.position, obj.transform.rotation);
                Destroy(GameObject.Find("Rework Smoke(Clone)"), 2f);
                controller.ControlObject(obj, true, controller);
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
            if (Input.GetKeyDown(KeyCode.A) && controller.isControlled)
            {
                ColorChanger changer = other.GetComponent<ColorChanger>();
                changer?.SwapColors(colorMgr); // Check if the changer exists and swap colors

                if (colorMgr.GetCurrentColor() == ObjectColor.YELLOW)
                {
                    Instantiate(yellowSmoke, controller.transform.position, controller.transform.rotation);
                    Destroy(GameObject.Find("Rework Yellow Smoke(Clone)"), 2f);
                }
                else if (colorMgr.GetCurrentColor() == ObjectColor.MAGENTA)
                {
                    Instantiate(magentaSmoke, controller.transform.position, controller.transform.rotation);
                    Destroy(GameObject.Find("Rework Magenta Smoke(Clone)"), 2f);
                }      
            }      
        }
    }

    public void CheckPoint(Vector3 newLocation)
    {
        respawnLocation = newLocation;
    }

    public void CurrentSpawnPoint(Vector3 newSpawn)
    {
        respawnLocation = newSpawn;
    }

    public void SelectedContinue()
    {
        respawnTarget.transform.position = respawnLocation;
    }
}