using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public ColorManager colorMgr;
    public BoxCollider barrierCollider;

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerManager player = collider.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
        }
        else if(collider.CompareTag("ControllableHeavy"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
        }  
        else if (collider.CompareTag("ControllableLightweight"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerManager player = collider.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = true;
            }
        }
        else if (collider.CompareTag("ControllableHeavy"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = true;
            }
        }
        else if (collider.CompareTag("ControllableLightweight"))
        {
            ObjectController obj = collider.GetComponent<ObjectController>();

            if (obj.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = true;
            }
        }        
    }
}
    
    