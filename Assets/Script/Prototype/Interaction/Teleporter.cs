using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
	public int y = SceneManager.GetActiveScene().buildIndex;
	public AudioClip teleporterSound;
	public Animator transition;
	public GameObject teleporterVisualEffect;
	public bool alreadyPlayed = false;
	public Transform vfxSpawnPoint;

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if(!alreadyPlayed)
			{
				AudioSource.PlayClipAtPoint(teleporterSound, transform.position);
				Instantiate(teleporterVisualEffect, vfxSpawnPoint.position, vfxSpawnPoint.rotation);
				RoomControl.instance.Victory();
				alreadyPlayed = true;
			}
			
			StartCoroutine("Teleport");
		}
	}

	IEnumerator Teleport()
	{	
		yield return new WaitForSeconds(1f);
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(y);
	}
}


