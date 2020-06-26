    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayerManager player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<PlayerManager>();
        Debug.Log(player.respawnLocation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player(Clone)")
        {
            player.CheckPoint(transform.position);
            Debug.Log(player.respawnLocation);
        }
    }
}
