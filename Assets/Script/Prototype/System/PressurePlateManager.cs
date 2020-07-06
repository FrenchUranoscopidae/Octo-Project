using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PressurePlateManager : MonoBehaviour
{
    public List<PressurePlateControllerUpdate> plates;
    public Door door;
    public Text pressurePlateCountText;
    public int plateCountNumber = 0;
    public int activatePlateCountNumber = 0;

    void Start()
    {
        pressurePlateCountText = pressurePlateCountText.GetComponent<Text>();

        foreach (var plate in plates)
        {
            plate.OnPressurePlateActivated += CheckPressurePlate;
        }
    }

     private void OnTriggerStay(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            plateCountNumber = plates.Count;
            pressurePlateCountText.text = activatePlateCountNumber + "/" + plateCountNumber;
        }   
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            pressurePlateCountText.text = null;
        }
    }

    void CheckPressurePlate()
    {
        bool canOpen = true;
        foreach(var plate in plates)
        {
            if (!plate.isActive)
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
