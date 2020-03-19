using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorIsOpen = false;
    private float alpha;
    private Vector3 startDoorEulers;
    private Vector3 endDoorEulers;

    void Start()
    {
        startDoorEulers = transform.eulerAngles;
        endDoorEulers = new Vector3(startDoorEulers.x, startDoorEulers.y + 90f, startDoorEulers.z);
    }

    void Update()
    {
        if(doorIsOpen)
        {
            alpha += Time.deltaTime;
            alpha = Mathf.Clamp(alpha, 0f, 1f);
            transform.eulerAngles = Vector3.Lerp(startDoorEulers, endDoorEulers, alpha);
            if (alpha >= 1f) return;
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