using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRect : MonoBehaviour {

	public float duration = 0;
	public bool isEnabled = false;

	private float secCount = 0;

	void OnEnable() {
		isEnabled = true;
	}

	void Update() {

		if (isEnabled) {

			if (secCount >= duration) {
				secCount = 0;
				isEnabled = false;
				this.gameObject.SetActive (false);
				return;
			}

			secCount += Time.deltaTime;

		}
	}

}
