using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushController : MonoBehaviour
{
    public float strenght = 1;
    public Rigidbody rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.right * strenght);
            //rb.AddForce(transform.up * strenght/2);
        }
    }


}
