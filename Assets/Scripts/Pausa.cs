using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour {

	private bool isPaused = false;

	void Awake() {
		this.transform.FindChild ("Pause").gameObject.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			Pause ();
		}
	}

	void Pause() {
		if (isPaused == true) {
			Time.timeScale = 1;
			isPaused = false;
			this.transform.FindChild ("Pause").gameObject.SetActive (false);
		} else {
			Time.timeScale = 0;
			isPaused = true;
			this.transform.FindChild ("Pause").gameObject.SetActive (true);
		}
	}
}
