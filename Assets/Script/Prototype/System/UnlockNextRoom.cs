using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextRoom : MonoBehaviour
{
    public Door jail;
    public Door room1;
    public Door room2;
    public Door room3;
    public Door room4;
    public PlayerController player;
    public Transform returnPoint;
    int roomPassed;

    private void Awake()
    {
        roomPassed = PlayerPrefs.GetInt("roomPassed");
        jail.CloseDoor();
        room1.OpenDoor();
        room2.CloseDoor();
        room3.CloseDoor();
        room4.CloseDoor();
    }

    void Start()
    {
        ResetPlayerPrefs();
   
        switch (roomPassed)
        {
            case 1:
                Instantiate(player, returnPoint.position, returnPoint.rotation);
                GameObject.Find("DoorManager").GetComponent<SpawnPlayer>().enabled = false;
                jail.OpenDoor();
                room1.OpenDoor();
                room2.OpenDoor();
                room3.CloseDoor();
                room4.CloseDoor();
                break;
            case 2:
                Instantiate(player, returnPoint.position, returnPoint.rotation);
                GameObject.Find("DoorManager").GetComponent<SpawnPlayer>().enabled = false;
                jail.OpenDoor();
                room1.OpenDoor();
                room2.OpenDoor();
                room3.OpenDoor();
                room4.CloseDoor();
                break;
            case 3:
                Instantiate(player, returnPoint.position, returnPoint.rotation);
                GameObject.Find("DoorManager").GetComponent<SpawnPlayer>().enabled = false;
                jail.OpenDoor();
                room1.OpenDoor();
                room2.OpenDoor();
                room3.OpenDoor();
                room4.OpenDoor();
                break;
        }
    }    
    
    void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        jail.CloseDoor();
        room1.OpenDoor();
        room2.CloseDoor();
        room3.CloseDoor();
        room4.CloseDoor();
    }
}
