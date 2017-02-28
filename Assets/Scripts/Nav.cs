using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Nav : MonoBehaviour {

	public AudioClip doorsActionSound;

	public bool activeAnimation = false;
	public string astraPosition = "inside";
	public bool doorsClosed = true;				// Questa potrebbe essere eliminata. Serve solo per il DEBUG
	public bool buttonPressed = false;

	private bool soundPlaying = false;

	private float degrees = 0;

	private Astra astra;

	// Use this for initialization
	void Start () {
		Astra.onNAVButtonPressed += NAVButtonPressed;
	}

	void NAVButtonPressed() {
		activeAnimation = true;
		buttonPressed = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (astraPosition == "outside") {

			if (buttonPressed) {

				// Porte NAV si chiudono
				if (closeDoors () == false) {
					buttonPressed = false;
					doorsClosed = true;
				}
			
			} else {
				
				// Porte NAV si aprono
				if (openDoors () == false) {
					doorsClosed = false;
				}

			} 

		}
			

		if (astraPosition == "inside") {

			if (buttonPressed) {

				// Porte NAV ci aprono
				if (openDoors () == false) {
					doorsClosed = false;
				}
			
			} else {

				// Porte NAV si chiudono
				if (closeDoors () == false) {
					doorsClosed = true;
				}
			
			}
		}
	}


	// Ritorna false quando l'azione è terminata
	bool openDoors() {

		if (activeAnimation) {

			if (degrees >= 90) {
				degrees = 90;
				activeAnimation = false;
				soundPlaying = false;
				return false;
			}

			if (!soundPlaying) {
				soundPlaying = true;
				this.GetComponent<AudioSource> ().PlayOneShot (doorsActionSound);
			}


			degrees++;
			this.gameObject.transform.FindChild ("Nav_portaD").transform.Rotate (new Vector3 (0.0f, 0.0f, -1f));
			this.gameObject.transform.FindChild ("Nav_portaS").transform.Rotate (new Vector3 (0.0f, 0.0f, 1f));
		}

		return true;

	}

	bool closeDoors() {

		if (activeAnimation) {

			if (degrees <= 0) {

				degrees = 0;
				activeAnimation = false;
				soundPlaying = false;
				return false;
			}

			if (!soundPlaying) {
				soundPlaying = true;
				this.GetComponent<AudioSource> ().PlayOneShot (doorsActionSound);
			}

			degrees--;
			this.gameObject.transform.FindChild ("Nav_portaD").transform.Rotate (new Vector3 (0.0f, 0.0f, 1f));
			this.gameObject.transform.FindChild ("Nav_portaS").transform.Rotate (new Vector3 (0.0f, 0.0f, -1f));
		}

		return true;


	}

}