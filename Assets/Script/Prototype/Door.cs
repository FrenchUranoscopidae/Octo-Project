using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public YellowPressurePlate yellowPressurePlate;
    public MagentaPressurePlate magentaPressurePlate;
    bool doorIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (yellowPressurePlate.isActive && magentaPressurePlate.isActive)
        {
            doorIsOpen = true;
        }
        else
        {
            doorIsOpen = false;
        }

        if (doorIsOpen)
        {
            Destroy(door);
        }
    }
}
