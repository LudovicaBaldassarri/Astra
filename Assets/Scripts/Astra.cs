using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astra : MonoBehaviour {

	public int energySphereCounter = 0;
	public float oxigenLevel = 100;
	public float oxigenLossPerSecond = 0;

	public delegate void AstraAction();
	public static event AstraAction onNAVButtonPressed;
	public static event AstraAction onButtonMontacarichiPressed;

	// Use this for initialization
	void Start () {
		EnergySphere.onTaken += IncrementEnergySphereCount;	
	}
	
	// Update is called once per frame
	void Update () {

		if (oxigenLevel < 0)
			print ("ATTENZIONE: OSSIGENO TERMINATO!!!!");
		else
			oxigenLevel -= oxigenLossPerSecond * Time.deltaTime;

	}

	void IncrementEnergySphereCount() {
		energySphereCounter++;
		print ("Numero di sfere di energia: " + energySphereCounter);
	}

	void FixedUpdate() {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);
		Debug.DrawRay (transform.position, transform.forward*10, new Color(255,0,0));

		if (Physics.Raycast (ray, out hit, 100.0f)) {

			// DEBUG:
			// print ("Found object (" + hit.collider.gameObject.name + ") distance: " + hit.distance);

			if (hit.collider.gameObject.tag == "Elemento") {

				print ("ASTRA: Elemento " + hit.collider.gameObject.name + " trovato!");
			
			} else if (hit.collider.gameObject.tag == "BottoneNav") {

				print ("ASTRA: Ho trovato il bottone di NAV!");
				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					onNAVButtonPressed();
				}

			} else if (hit.collider.gameObject.tag == "BottoneMontacarichi"){

				print ("ASTRA: Ho trovato il bottone del montacarichi!");

				if (Input.GetMouseButtonDown (0)) {	// MOUSE LEFT CLICK
					onButtonMontacarichiPressed();
				}

			}
		}
	}

}
