using System.Collections.Generic;
using UnityEngine;

public class PressurePlaterManager : MonoBehaviour
{
    public List<PressurePlateController> plates;
    public Door door;

    void Start()
    {
        foreach (var p in plates)
        {
            p.OnPressurePlateActivated += CheckPressurePlate;
        }
    }

    void CheckPressurePlate()
    {
        bool canOpen = true;
        foreach(var p in plates)
        {
            if (!p.isActive)
            {
                canOpen = false;
                break;
            }
        }

        if (canOpen) door.OpenDoor();
    }
}
