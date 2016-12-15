using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astra : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.forward);


		if (Physics.Raycast (ray, out hit, 100.0f)) {
			print ("Found object (" + hit.collider.gameObject.name + ") distance: " + hit.distance);
			Debug.DrawRay (transform.position, forward);
		}
	}
}
