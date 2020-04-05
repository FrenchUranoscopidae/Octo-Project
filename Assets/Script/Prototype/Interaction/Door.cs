using UnityEngine;

public class Door : MonoBehaviour
{
    public BoxCollider doorCollider;
    public bool doorIsOpen = false;
    private Animator openDoor;

    void Start()
    {
        openDoor = gameObject.GetComponent<Animator>();
        doorCollider.enabled = true;
    }

    void Update()
    {
        if(doorIsOpen == true)
        {
            openDoor.SetBool("openDoor", true);
            doorCollider.enabled = false;
        }
    }

    public void OpenDoor()
    {
        doorIsOpen = true;
    }

    public void CloseDoor()
    {
        doorIsOpen = false;
    }
}