using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZQSDTuto : MonoBehaviour
{
    public GameObject zqsdTuto;
    public bool hasActivated = false;
    public float ZQSDTutoTimer;

    void Start()
    {
        StartCoroutine("ZQSDTutoWait");
    }

    IEnumerator ZQSDTutoWait()
    {
        yield return new WaitForSeconds(ZQSDTutoTimer);
        hasActivated = true;
    }

    private void OnTriggerStay(Collider col)
    {
        if(hasActivated)
        {
            zqsdTuto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        zqsdTuto.SetActive(false);
    }
}
