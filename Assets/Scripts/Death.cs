using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public float respawnX;
	public float respawnY;
	public float respawnZ;

	public AudioClip deathSound;

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Player")) {

			GetComponent<AudioSource> ().PlayOneShot (deathSound);
			other.gameObject.transform.position = new Vector3(respawnX,respawnY,respawnZ);
		}
	}
}
