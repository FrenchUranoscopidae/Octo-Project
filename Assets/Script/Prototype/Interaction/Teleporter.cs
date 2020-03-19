using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
	public int y = SceneManager.GetActiveScene().buildIndex;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			RoomControl.instance.Victory();
			SceneManager.LoadScene(y);	
		}
	}
}


