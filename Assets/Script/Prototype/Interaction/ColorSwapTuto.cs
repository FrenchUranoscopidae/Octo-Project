using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapTuto : MonoBehaviour
{
    public GameObject colorSwapTuto;
    public bool hasActivated = false;

    private void OnTriggerEnter (Collider col)
    {
        colorSwapTuto.SetActive(true);
    }

    private void OnTriggerExit(Collider col)
    {

        colorSwapTuto.SetActive(false);
    }
}
