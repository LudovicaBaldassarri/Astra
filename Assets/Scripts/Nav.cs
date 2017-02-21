using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Nav : MonoBehaviour {

	public AudioClip doorsActionSound;

	private bool closed = true;
	private bool anim = false;
	private float degrees = 0;

	private Astra astra;

	// Use this for initialization
	void Start () {
		Astra.onNAVButtonPressed += NAVButtonPressed;
	}

	void NAVButtonPressed() {
		anim = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (anim) {

			int sign = 1;

			// FIXME: rendilo framrate independent
			if (closed) {
				degrees++;
				sign = 1;
			} else {
				degrees--;
				sign = -1;
			}

			// TODO: do the animation here

//			for (int i = 0; i < this.transform.childCount - 1; i++) {
//				if (this.transform.GetChild (i).transform.name == "Nav_portaDx") {
//					this.transform.GetChild(i).transform.Rotate(new Vector3(0.0f,0.0f,sign*-1f));
//				} else if (this.transform.GetChild (i).transform.name == "Nav_PortaSx") {
//					this.transform.GetChild(i).transform.Rotate(new Vector3(0.0f,0.0f,sign*1f));
//				}
//			}
			this.gameObject.transform.FindChild("Nav_portaD").transform.Rotate(new Vector3(0.0f,0.0f,sign*-1f));
			this.gameObject.transform.FindChild("Nav_portaS").transform.Rotate(new Vector3(0.0f,0.0f,sign*1f));

			/*
			this.transform.GetChild(1).transform.Rotate(new Vector3(0.0f,0.0f,sign*-1f));
			this.transform.GetChild(2).transform.Rotate(new Vector3(0.0f,0.0f,sign*1f));
			this.transform.GetChild(3).transform.Rotate(new Vector3(0.0f,0.0f,sign*1f));
			*/

			if (degrees >= 90 || degrees <= 0) {
				anim = false;
				closed = !closed;
			}
		}
	}

	void OnTriggerEnter(Collider collision) {
		anim = true;
		this.GetComponent<AudioSource> ().PlayOneShot (doorsActionSound);
	}
}
