using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
	public int y = SceneManager.GetActiveScene().buildIndex;
	public AudioClip teleporterSound;
	public GameObject teleporterVisualEffect;
	public Transform vfxSpawnPoint;

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			AudioSource.PlayClipAtPoint(teleporterSound, transform.position);
			Instantiate(teleporterVisualEffect, vfxSpawnPoint.position, vfxSpawnPoint.rotation);
			RoomControl.instance.Victory();
			StartCoroutine("Teleport");
		}
	}

	IEnumerator Teleport()
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(y);
	}
}


