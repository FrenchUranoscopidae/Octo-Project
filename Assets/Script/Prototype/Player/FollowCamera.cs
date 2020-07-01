using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;

    public bool controllingObject = false;

	void Start()
	{
		offset = new Vector3(0, 30, -15);
	}

	void LateUpdate()
	{
        if(!controllingObject)
        {
            if (player == null)
            {
                player = GameObject.Find("Player(Clone)").transform;
            }
            else
            {
                transform.position = player.transform.position + offset;
            }
        }
		/*if (player == null)
		{
			player = GameObject.Find("Player(Clone)").transform;
		}
		else
		{
			transform.position = player.transform.position + offset;
		}*/

        if(controllingObject)
        {

        }
	}
}
