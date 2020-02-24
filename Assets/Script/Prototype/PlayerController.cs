using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject lastCol;
    Material origin;
    Renderer rend;
    Rigidbody rb;

    public Material yellowMaterial;
    public Material magentaMaterial;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        origin = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        float posx = Input.GetAxis("Horizontal");
        float posy = Input.GetAxis("Vertical");

        transform.Translate(0, 0, posy / 5);
        transform.Rotate(0, posx, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MagentaSwitch")
        {
            rend.material = magentaMaterial;
            gameObject.tag = "MagentaPlayer";
            other.gameObject.GetComponent<Renderer>().material = yellowMaterial;
            other.gameObject.tag = "YellowSwitch";

        }
        else if(other.gameObject.tag == "YellowSwitch")
        {
            rend.material = yellowMaterial;
            gameObject.tag = "YellowPlayer";
            other.gameObject.GetComponent<Renderer>().material = magentaMaterial;
            other.gameObject.tag = "MagentaSwitch";
        }
    }
}
