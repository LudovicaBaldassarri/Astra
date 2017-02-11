using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montacarichi : MonoBehaviour {

	public float StopLevelDown;
	public float speedDown;

	private bool goDown = false;

	// Use this for initialization
	void Start () {
		Astra.onButtonMontacarichiPressed += MontacarichiButtonPressed;
	}

	void MontacarichiButtonPressed() {
		goDown = true;
		this.gameObject.transform.FindChild ("Boundaries").gameObject.GetComponent<MeshCollider> ().enabled = true;
	}

	// Update is called once per frame
	void Update () {

		if (goDown) {
			Vector3 pos = this.gameObject.transform.position;

			if (pos.y > StopLevelDown) {

				this.gameObject.transform.Translate (new Vector3 (0f, -speedDown*Time.deltaTime, 0f));

			} else {

				goDown = false;
				this.gameObject.transform.FindChild ("Boundaries").gameObject.GetComponent<MeshCollider> ().enabled = false;

			}

		}
	
	}
}
