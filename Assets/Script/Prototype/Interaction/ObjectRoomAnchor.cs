using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomAnchor : MonoBehaviour
{
    public BoxCollider anchorCollider;

    [Header("PlateCount")]
    public bool displayPlateCount = false;
    public GameObject PlateCountUI;

    void Start()
    {
        //displayPlateCount = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            if (displayPlateCount)
            {
                PlateCountUI.SetActive(true);
                Debug.Log("PlateCountDisplay");
            }

            if(!displayPlateCount)
            {
                PlateCountUI.SetActive(false);
            }
        }
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
