using System.Collections.Generic;
using UnityEngine;

public class PressurePlateManager : MonoBehaviour
{
    public List<PressurePlateController> plates;
    public Door door;
    public int PlateCountNumber;

    void Start()
    {
        foreach (var p in plates)
        {
            p.OnPressurePlateActivated += CheckPressurePlate;
        }
    }

    void Update()
    {
        PlateCountNumber = plates.Count;
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

        if (canOpen)
        {
            door.OpenDoor();
        }
    }
}
