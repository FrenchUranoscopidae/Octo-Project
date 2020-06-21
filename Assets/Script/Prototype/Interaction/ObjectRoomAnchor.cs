using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomAnchor : MonoBehaviour
{
    public BoxCollider anchorCollider;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            anchorCollider.enabled = false;
        }
        else
        {
            anchorCollider.enabled = true;
        }
    }
}
