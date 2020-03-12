using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public ColorManager colorMgr;
    public bool isActive = false;
    public int pressurePlateValue;

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
                    ActivatePressurePlate();
                }
            }
        }
        else if (collider.CompareTag("ControllableLightweight"))
        {
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                pressurePlateValue++;

                    if (pressurePlateValue == 2)
                {
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
        }

        if(collider.gameObject.tag == "ControllableLightweight")
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
