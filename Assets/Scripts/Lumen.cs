using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumen : MonoBehaviour {

	// Modificabili dall'esterno
	public float rotationSpeed = 4f;


	// Use this for initialization
	void Start () {

	}

	void Awake() {
		iTween.Init (this.gameObject);
	}

	// Update is called once per frame
	void Update () {

		// Rotazione sul proprio asse verticale
		float rot = rotationSpeed * 100 * Time.deltaTime;
		transform.Rotate (new Vector3 (0f, 0f, rot));

	}
}
