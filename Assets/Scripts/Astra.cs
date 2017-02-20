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

	public delegate void AstraAction();
	public static event AstraAction onNAVButtonPressed;
	public static event AstraAction onButtonMontacarichiPressed;

	void Awake () {
		currentOxigen = startOxigen;
		EnergySphere.onTaken += IncrementEnergySphereCount;
		OxigenRefill.onInsideNav += RefillOxigen;
		NewBehaviourScript.onOxigenDamage += OxigenDamage;
	}
	
	// Update is called once per frame
	void Update () {

		if (currentOxigen == 0) {
			print ("ATTENZIONE: OSSIGENO TERMINATO!!!!");
			// MUORI QUI!!!

		} else {
			currentOxigen -= oxigenLossPerSecond * Time.deltaTime;

			if (currentOxigen < 0) {
				currentOxigen = 0;
			}

			oxigenSlider.value = currentOxigen;
		}

	}

	void RefillOxigen() {
		currentOxigen = 100;
	}

	void OxigenDamage() {
		currentOxigen -= 2;
		if (currentOxigen < 0)
			currentOxigen = 0;
	}

	void IncrementEnergySphereCount() {
		energySphereCounter++;
		sphereCounter.text = energySphereCounter.ToString ();
	}

	void FixedUpdate() {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward*10, new Color(255,0,0));

		if (Physics.Raycast (ray, out hit, 3.0f)) {

			// DEBUG:
			// print ("Found object (" + hit.collider.gameObject.name + ") distance: " + hit.distance);

			if (hit.collider.gameObject.tag == "Elemento") {

				// Testo per debug
				//print ("ASTRA: Elemento " + hit.collider.gameObject.name + " trovato!");

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					hit.collider.gameObject.transform.FindChild("didascalia").gameObject.SetActive(true);
				}
			
			} else if (hit.collider.gameObject.tag == "BottoneNav") {

				// Testo per debug
				//print ("ASTRA: Ho trovato il bottone di NAV!");

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					onNAVButtonPressed();
				}

			} else if (hit.collider.gameObject.tag == "BottoneMontacarichi"){

				// Testo per debug
				//print ("ASTRA: Ho trovato il bottone del montacarichi!");

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					onButtonMontacarichiPressed();
				}

			}
		}
	}

}
