using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    public ColorManager colorMgr;
    public BoxCollider barrierCollider;

    void OnCollisionEnter(Collision collision)
    {
        Collider col = collision.collider;
        if (col.CompareTag("Player"))
        {
            PlayerManager player = col.GetComponent<PlayerManager>();

            if (player.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
            else
            {
                barrierCollider.enabled = true;
            }
        }

        if(col.CompareTag("ControllableHeavy"))
        {
            ObjectController objH = col.GetComponent<ObjectController>();

            if (objH.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
            else
            {
                barrierCollider.enabled = true;
            }

        }
        
        if (col.CompareTag("ControllableLightweight"))
        {
            ObjectController objL = col.GetComponent<ObjectController>();

            if (objL.colorMgr.GetCurrentColor() == colorMgr.GetCurrentColor())
            {
                barrierCollider.enabled = false;
            }
            else
            {
                barrierCollider.enabled = true;
            }
        }
    }
}
    
    