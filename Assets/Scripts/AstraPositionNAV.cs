using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstraPositionNAV : MonoBehaviour {

	public string triggerPosition;

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "Player") {

			this.transform.parent.GetComponent<Nav> ().astraPosition = triggerPosition;
			this.transform.parent.GetComponent<Nav> ().activeAnimation = true;
			//this.GetComponent<AudioSource> ().PlayOneShot (doorsActionSound);
		}

	}

}
