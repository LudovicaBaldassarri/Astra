using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggCollider : MonoBehaviour {

	void Awake() {
		string bombolaString = PlayerPrefs.GetString ("bombola");

		if (bombolaString == "found") {
			this.GetComponent<BoxCollider> ().enabled = false;
		}

	}
}
