using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public ColorManager colorMgr;
    public bool isActive = false;
    public int pressurePlateValue = 0;

    public int lightOnPlateCount = 0;
    public bool playerOnPlate = false;
    public bool playerOnPlatePos = false;

    public GameObject diodeColor;
    public GameObject diodeColor1;
    public GameObject pressurePlate;
    public Material initialMaterial;

    [Header("Sound")]
    public AudioClip PlateActivation;
    public float volume;
    public bool b_HasActivated = false;

    [Header("Dialogue")]
    public bool b_dialogueHappenned = false;
    public DialogueTrigger dialogueTrigger;

    public delegate void OnPressurePlateActivatedDelegate();
    public event OnPressurePlateActivatedDelegate OnPressurePlateActivated;

    public bool b_All = true;

    [Header("Animation")]
    public float loweringValue1;
    public float loweringValue2;

    public void Start()
    {
        pressurePlate.transform.position = transform.position + new Vector3(0, 0, 0);
    }
    public void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerManager player = collider.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue = collider.GetComponent<PlayerController>().weight;

                if (pressurePlateValue == 2)
                {
                    diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    ActivatePressurePlate();

                    //Sound
                    if (!b_HasActivated)
                    {
                        AudioSource.PlayClipAtPoint(PlateActivation, transform.position, volume);
                        b_HasActivated = true;
                    }

                }
            }
        }

        if (collider.CompareTag("ControllableHeavy"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue = collider.GetComponent<ObjectController>().weight;

                if (pressurePlateValue == 2)
                {
                    diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    ActivatePressurePlate();

                    //Sound
                    if (!b_HasActivated)
                    {
                        AudioSource.PlayClipAtPoint(PlateActivation, transform.position, volume);
                        b_HasActivated = true;
                    }
                }
            }
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ControllableLightweight"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue++;
                diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                lightOnPlateCount += 1;
                pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue1, 0);

                if (pressurePlateValue == 2)
                {
                    diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    ActivatePressurePlate();

                    //Sound
                    if (!b_HasActivated)
                    {
                        AudioSource.PlayClipAtPoint(PlateActivation, transform.position, volume);
                        b_HasActivated = true;
                    }
                }

                //Dialogue
                if (!b_dialogueHappenned)
                {
                    ThisObjectDialogueTrigger();
                }
            }
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.CompareTag("ControllableHeavy"))
        {
            isActive = false;
            pressurePlateValue = 0;
            pressurePlate.transform.position = transform.position + new Vector3(0, 0, 0);
            diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
            diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;

            b_HasActivated = false;
        }
                
        if (collider.CompareTag("Player"))
        {   
            if(lightOnPlateCount == 0)
            {
                isActive = false;
                pressurePlateValue = 0;
                pressurePlate.transform.position = transform.position + new Vector3(0, 0, 0);
                diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
                diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;
            }

            if(lightOnPlateCount == 1)
            {
                isActive = false;
                pressurePlateValue = 1;
                pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue1, 0);
                diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
                diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }

            if (lightOnPlateCount == 2)
            {
                isActive = false;
                pressurePlateValue = 2;
                diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }

            b_HasActivated = false;
        }

        if (collider.CompareTag("ControllableLightweight"))
        {
            if(lightOnPlateCount == 1)
            {
                pressurePlateValue--;
                isActive = false;
                pressurePlate.transform.position = transform.position + new Vector3(0, 0, 0);
                diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
                diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;
            }

            if(lightOnPlateCount == 2)
            {
                pressurePlateValue--;
                isActive = false;
                pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue1, 0);
                diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
                diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
            }
            lightOnPlateCount -= 1;

            b_HasActivated = false;
        }
    }

    private void ActivatePressurePlate()
    {
        isActive = true;
        OnPressurePlateActivated?.Invoke();
        pressurePlate.transform.position = transform.position + new Vector3(0, loweringValue2, 0);
    }

    public void ThisObjectDialogueTrigger()
    {
        dialogueTrigger.TriggerDialogue();
        b_dialogueHappenned = true;
        //Debug.Log(b_dialogueHappenned);
    }
}
