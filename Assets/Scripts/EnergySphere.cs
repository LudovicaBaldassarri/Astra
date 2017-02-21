using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnergySphere : MonoBehaviour {

	public delegate void EnergySphereAction();
	public static event EnergySphereAction onTaken;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider collision) {
		
		gameObject.SetActive (false);
		onTaken ();
	}
}
