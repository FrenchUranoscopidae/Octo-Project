using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapTuto : MonoBehaviour
{
    public GameObject colorSwapTuto;
    public bool hasActivated = false;

    /*void Update()
    {
        if(hasActivated)
        {
            colorSwapTuto.SetActive(false);
        }
    }*/

    private void OnTriggerEnter (Collider col)
    {
        /*if(!hasActivated)
        {
            colorSwapTuto.SetActive(true);
        }*/

        colorSwapTuto.SetActive(true);
    }

    private void OnTriggerExit(Collider col)
    {
        /*if (!hasActivated)
        {
            colorSwapTuto.SetActive(false);
        }*/

        colorSwapTuto.SetActive(false);
    }

    /*private void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            hasActivated = true;
        }
    }*/
}
