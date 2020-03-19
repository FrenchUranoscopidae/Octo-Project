using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextRoom : MonoBehaviour
{
    public Door room1;
    public Door room2;
    public Door room3;
    public Door room4;
    int roomPassed;

    private void Awake()
    {
        roomPassed = PlayerPrefs.GetInt("roomPassed");
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
                room1.OpenDoor();
                room2.OpenDoor();
                room3.CloseDoor();
                room4.CloseDoor();
                break;
            case 2:
                room1.OpenDoor();
                room2.OpenDoor();
                room3.OpenDoor();
                room4.CloseDoor();
                break;
            case 3:
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
        room1.OpenDoor();
        room2.CloseDoor();
        room3.CloseDoor();
        room4.CloseDoor();
    }
}
