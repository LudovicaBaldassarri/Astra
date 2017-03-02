using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Astra : MonoBehaviour {

	public int energySphereCounter = 0;
	public float currentOxigen;
	public float startOxigen = 100;
	public float oxigenLossPerSecond = 0;
	public Slider oxigenSlider;
	public Text sphereCounter;
	public Image selector;
	public AudioClip energyTakenSound;
	public AudioClip didascaliaSound;
	public AudioClip deathSound;

	public int totaleSfere;

	public Image damageRectangle;

	public delegate void AstraAction();
	public static event AstraAction onNAVButtonPressed;
	public static event AstraAction onButtonMontacarichiPressed;

	private Vector3 lastCheckpoint;

	void Awake () {
		currentOxigen = startOxigen;
		EnergySphere.onTaken += IncrementEnergySphereCount;
		OxigenRefill.onInsideNav += RefillOxigen;
		NewBehaviourScript.onOxigenDamage += OxigenDamage;
		lastCheckpoint = this.transform.parent.transform.position;
		PlayerPrefs.SetString ("bombola", "notfound");
		PlayerPrefs.SetInt ("energy", energySphereCounter);
	}

	void OnDestroy() {
		EnergySphere.onTaken -= IncrementEnergySphereCount;
	}

	// Update is called once per frame
	void Update () {

		if (currentOxigen == 0) {

			//print ("ATTENZIONE: OSSIGENO TERMINATO!!!!");

			if(deathSound != null)
				this.GetComponent<AudioSource> ().PlayOneShot (deathSound);

			this.transform.parent.transform.position = lastCheckpoint;
			currentOxigen = 100;

		} else {
			currentOxigen -= oxigenLossPerSecond * Time.deltaTime;

			if (currentOxigen < 0) {
				currentOxigen = 0;
			}

			oxigenSlider.value = currentOxigen;
		}

		if (this.transform.parent.transform.position.y < -2)
			currentOxigen = 100;

	}

	void RefillOxigen() {
		currentOxigen = 100;
	}

	void OxigenDamage() {

		if (damageRectangle != null) {
			damageRectangle.gameObject.SetActive (true);
		}

		currentOxigen -= 50;
		if (currentOxigen < 0)
			currentOxigen = 0;
	}

	void IncrementEnergySphereCount() {
		this.GetComponent<AudioSource> ().PlayOneShot (energyTakenSound);
		energySphereCounter++;
		sphereCounter.text = energySphereCounter.ToString () + " / " + totaleSfere.ToString ();
		PlayerPrefs.SetInt ("energy", energySphereCounter);
	}

	void FixedUpdate() {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward*10, new Color(255,0,0));

		selector.enabled = false;

		if (Physics.Raycast (ray, out hit, 3.0f)) {

			// DEBUG:
			// print ("Found object (" + hit.collider.gameObject.name + ") distance: " + hit.distance);

			if (hit.collider.gameObject.tag == "Elemento") {

				// Testo per debug
				//print ("ASTRA: Elemento " + hit.collider.gameObject.name + " trovato!");
				selector.enabled = true;

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					hit.collider.gameObject.transform.FindChild ("didascalia").gameObject.SetActive (true);
					this.GetComponent<AudioSource> ().PlayOneShot (didascaliaSound);
				}
			
			} else if (hit.collider.gameObject.tag == "BottoneNav") {

				// Testo per debug
				//print ("ASTRA: Ho trovato il bottone di NAV!");
				selector.enabled = true;

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					this.GetComponent<AudioSource> ().PlayOneShot (didascaliaSound);
					onNAVButtonPressed ();
					lastCheckpoint = this.transform.parent.transform.position;
				}

			} else if (hit.collider.gameObject.tag == "BottoneMontacarichi") {

				// Testo per debug
				//print ("ASTRA: Ho trovato il bottone del montacarichi!");
				selector.enabled = true;

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					this.GetComponent<AudioSource> ().PlayOneShot (didascaliaSound);
					onButtonMontacarichiPressed ();
				}
			} else if (hit.collider.gameObject.tag == "Bombola") {

				selector.enabled = true;

				if (Input.GetMouseButton (0)) {
					this.GetComponent<AudioSource> ().PlayOneShot (didascaliaSound);
					PlayerPrefs.SetString ("bombola", "found");
					hit.collider.gameObject.SetActive (false);
				}
			}
		}
	}

}
