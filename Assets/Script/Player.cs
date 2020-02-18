using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int colorID;

    Renderer playerRender;
    GameObject attachedObject;
    public Material material0;
    public Material material1;

    void Start()
    {
        colorID = 0;
        playerRender = GetComponent<Renderer>();
    }

    void Update()
    {
        float posx = Input.GetAxis("Horizontal");
        float posy = Input.GetAxis("Vertical");

        transform.Translate(0, 0, posy / 5);
        transform.Translate(posx / 5, 0, 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            playerRender.enabled = true;
            attachedObject.transform.parent = null;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(colorID == 0)
            {
                playerRender.material = material1;
                colorID = 1;
            }
            else
            {
                playerRender.material = material0;
                colorID = 0;
            }
        }

        Debug.Log(attachedObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*Checks player color, it attaches collision object if it matches and disables player object rendering*/
        if (colorID == 0)
        {
            if (collision.gameObject.CompareTag("color0"))
            {
                Morph(collision);
            }
        }

        else
        {
            if (collision.gameObject.CompareTag("color1"))
            {
                Morph(collision);
            }
        }
    }

    public void Morph(Collision collision)
    {
        attachedObject = collision.gameObject;
        playerRender.enabled = false;
        attachedObject.transform.parent = transform;
    }

    public void RaycastCheck()
    {
        
    }
}
