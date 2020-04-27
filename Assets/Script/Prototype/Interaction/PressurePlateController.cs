﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public ColorManager colorMgr;
    public bool isActive = false;
    public int pressurePlateValue = 0;
    public GameObject diodeColor;
    public GameObject diodeColor1;
    public Material initialMaterial;

    public delegate void OnPressurePlateActivatedDelegate();
    public event OnPressurePlateActivatedDelegate OnPressurePlateActivated;

    public void OnTriggerEnter(Collider collider)
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
                }
            }
        }

        ObjectController obj = collider.GetComponent<ObjectController>();

        if (collider.CompareTag("ControllableHeavy"))
        {
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue = collider.GetComponent<ObjectController>().weight;

                if (pressurePlateValue == 2)
                {
                    diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    ActivatePressurePlate();
                }
            }
        }
        else if (collider.CompareTag("ControllableLightweight"))
        {
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue++;
                diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);

                if (pressurePlateValue == 2)
                {
                    diodeColor.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    diodeColor1.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    ActivatePressurePlate();
                }
            }
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "ControllableHeavy")
        {
            isActive = false;
            pressurePlateValue = 0;
            diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
            diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;
        }

        if (collider.gameObject.tag == "Player")
        {
            isActive = false;
            pressurePlateValue = 0;
            diodeColor.GetComponent<MeshRenderer>().material = initialMaterial;
            diodeColor1.GetComponent<MeshRenderer>().material = initialMaterial;
        }

        if (collider.gameObject.tag == "ControllableLightweight")
        {
            pressurePlateValue--;
            isActive = false;

        }
        
    }

    private void ActivatePressurePlate()
    {
        isActive = true;
        OnPressurePlateActivated?.Invoke();
    }
}
