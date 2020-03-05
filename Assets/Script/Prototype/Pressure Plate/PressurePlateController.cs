using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateController : MonoBehaviour
{
    public ColorManager colorMgr;
    public bool isActive = false;

    public delegate void OnPressurePlateActivatedDelegate();
    public event OnPressurePlateActivatedDelegate OnPressurePlateActivated;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerManager player = collider.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                ActivatePressurePlate();
            }
        }

        ObjectController obj = collider.GetComponent<ObjectController>();

        if (collider.CompareTag("Controllable"))
        {
            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                ActivatePressurePlate();
            }
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        isActive = false;
    }

    private void ActivatePressurePlate()
    {
        isActive = true;
        OnPressurePlateActivated?.Invoke();
    }
}
