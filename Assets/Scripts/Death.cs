using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public float respawnX;
	public float respawnY;
	public float respawnZ;

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Player")) {
			// Riporta ASTRA all'inizio del gioco
			// TODO: Da cambiare!
			other.gameObject.transform.position = new Vector3(respawnX,respawnY,respawnZ);
		}
	}
}
