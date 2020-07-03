using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateControllerUpdate : MonoBehaviour
{
    public ColorManager colorMgr;
    public bool isActive = false;
    public bool isSemiActive;
    public bool isColliding;
    public int pressurePlateValue = 0;
    public List<Collider> listObjectColliding = new List<Collider>();

    public int lightOnPlateCount = 0;
    public bool playerOnPlate = false;
    public bool playerOnPlatePos = false;

    public GameObject diodeColor;
    public GameObject diodeColor1;
    public GameObject pressurePlate;
    public Material initialMaterial;
    public PlayerController playerController;

    //Puzzle End
    public GameObject door;

    [Header("Sound")]
    public AudioClip PlateActivation;
    public float volume;
    public bool HasSoundActivated = false;

    [Header("Dialogue")]
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    public delegate void OnPressurePlateActivatedDelegate();
    public event OnPressurePlateActivatedDelegate OnPressurePlateActivated;

    public bool b_All = true;

    [Header("Animation")]
    public float loweringValue1;
    public float loweringValue2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        isColliding = false;
    }

    public void OnTriggerStay(Collider collider)
    {
        isColliding = true;
        
        if(collider.CompareTag("Player"))
        {
            PlayerManager player = collider.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                if (GameObject.Find("Player(Clone)").GetComponent<PlayerController>().isControlled)
                {
                    AddToObjectCollidingList(collider);
                }
                else if (GameObject.Find("Player(Clone)").GetComponent<PlayerController>().isControlled == false)
                {
                    RemoveToObjectCollidingList(collider);
                }
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if(!collider.CompareTag("Player"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                AddToObjectCollidingList(collider);
            }
        } 
    }

    public void OnTriggerExit(Collider collider)
    {
        listObjectColliding.Remove(collider);
        HasSoundActivated = false;
    }

    void Update()
    {
        pressurePlateValue = 0;

        if (GameObject.Find("Player(Clone)").GetComponent<PlayerController>().isControlled == false)
        {
            RemoveToObjectCollidingList(GameObject.Find("Player(Clone)").GetComponent<CharacterController>());  
        }

        if (isColliding)
        {
            if (listObjectColliding.Count == 1 && listObjectColliding[0].CompareTag("ControllableLightweight"))
            {
                //Dialogue
                if (!b_dialogueHappenned)
                {
                    ThisObjectDialogueTrigger();
                }

                pressurePlateValue = 1;
            }
            else if(listObjectColliding.Count == 1 && listObjectColliding[0].CompareTag("ControllableHeavy"))
            {
                pressurePlateValue = 2;
            }
            else if(listObjectColliding.Count == 1 && listObjectColliding[0].CompareTag("Player"))
            {
                pressurePlateValue = 2;
            }
            else if (listObjectColliding.Count == 2 && listObjectColliding[0].CompareTag("ControllableLightweight"))
            {
                pressurePlateValue = 2;
            }

        }

        PressurePlateState(pressurePlateValue);


        if (door.GetComponent<Door>().doorIsOpen)
        {
            PressurePlateState(2);
        } 
    }

    void PressurePlateState(int state)
    {
        if(state == 0)
        {
            isActive = false;
            pressurePlate.transform.position = transform.position + new Vector3(0, 0, 0);
            diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
            diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;
        }
        else if(state == 1)
        {
            isSemiActive = true;
            pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue1, 0);
            diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
            diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
        }
        else if(state == 2)
        {
            isActive = true;
            OnPressurePlateActivated?.Invoke();
            diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue2, 0);

            //Sound
            if (!HasSoundActivated)
            {
                AudioSource.PlayClipAtPoint(PlateActivation, transform.position, volume);
                HasSoundActivated = true;
            }
        }
    }

    public void AddToObjectCollidingList(Collider collider)
    {
        if(listObjectColliding.Contains(collider))
        {
            return;
        }
        else
        {
            listObjectColliding.Add(collider);
        }
    }

    public void RemoveToObjectCollidingList(Collider collider)
    {
        if (listObjectColliding.Contains(collider))
        {
            listObjectColliding.Remove(collider);
        }
        else
        {
            return;
        }
    }

    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
    }
}
