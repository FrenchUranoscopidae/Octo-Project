using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeposTuto : MonoBehaviour
{
    public GameObject deposTuto;
    public bool hasActivated = false;

    void Update()
    {
        if (hasActivated)
        {
            deposTuto.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!hasActivated)
        {
            deposTuto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (!hasActivated)
        {
            deposTuto.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hasActivated = true;
        }
    }
}
