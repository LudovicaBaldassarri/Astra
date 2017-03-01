using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectCollider : MonoBehaviour {

	public AudioClip soundEffect;
	public bool playOnce = true;

	void OnTriggerEnter() {
			
		this.GetComponent<AudioSource> ().PlayOneShot (soundEffect);

		if (playOnce) {
			this.gameObject.GetComponent<BoxCollider> ().enabled = false;
		}

	}
}
