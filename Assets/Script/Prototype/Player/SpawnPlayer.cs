using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public PlayerController player;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }
}
