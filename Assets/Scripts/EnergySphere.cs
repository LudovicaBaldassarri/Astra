using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision) {
		Debug.Log ("Collisione Energia!");
		gameObject.SetActive (false);
	}
}
