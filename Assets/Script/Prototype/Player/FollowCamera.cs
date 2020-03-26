using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;

	void Start()
	{
		offset = new Vector3(0, 20, -10);
	}

	void LateUpdate()
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
}
