using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Player")) {
			// Riporta ASTRA all'inizio del gioco
			// TODO: Da cambiare!
			other.gameObject.transform.position = new Vector3(-26,18,89);
		}
	}
}
