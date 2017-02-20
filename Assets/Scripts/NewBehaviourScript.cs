using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public delegate void OxigenDamage ();
	public static event OxigenDamage onOxigenDamage;

	public int count;
	public GameObject astra;
	public bool astra_collision = false;
	public bool particle_active = true;

	// Check if Astra enter the particle system
	void OnParticleCollision(GameObject other){
		if(other.gameObject.name == "Astra"){
			//Debug.Log ("collisione");
			//astra_collision = true;
			onOxigenDamage();

		}
	}

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		count++;
		if (this.gameObject.GetComponent<ParticleSystem>()) {
			if (count == 250) {
				this.gameObject.GetComponent<ParticleSystem>().Stop();
				particle_active = false;
				//astra_collision = false;
			}
			if (count == 350) {
				count = 0;
				this.gameObject.GetComponent<ParticleSystem>().Play ();
				particle_active = true;
			}
		}

		// Eliminare questa parte?
		/*
		if(astra_collision == true && particle_active == true){
			// Kill her!
			//Debug.Log("Astra è Morta!");
		}
		*/
	}
}
