using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomControl : MonoBehaviour
{
    public static RoomControl instance = null;
    private int sceneIndex;
    private int roomPassed;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        roomPassed = PlayerPrefs.GetInt("roomPassed");
    }

    public void Victory()
    {
        if (roomPassed < sceneIndex)
        {
            PlayerPrefs.SetInt("roomPassed", sceneIndex);
        }
    }
}

