using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRoomAnchor : MonoBehaviour
{
    public BoxCollider anchorCollider;

    [Header("PlateCount")]
    public GameObject PlateCountUI;
    //public bool displayPlateCount = false;

    public int PlateCount;
    public Text PlateCountTxt;

    void Start()
    {
        //displayPlateCount = true;
    }

    void Update()
    {
        //PlateCountTxt.text = PlateCount.ToString();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            /*if (displayPlateCount)
            {
                PlateCountUI.SetActive(true);
            }

            if(!displayPlateCount)
            {
                PlateCountUI.SetActive(false);
            }*/
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
