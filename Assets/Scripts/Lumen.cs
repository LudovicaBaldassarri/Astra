using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumen : MonoBehaviour {

	public float limit = 0.2f;
	public float increment = 0.001f;
	// float float_speed = 0.2;

	private float float_increment;
	private float float_sign;

	// Use this for initialization
	void Start () {
		float_increment = 0f;
		float_sign = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (new Vector3 (0f, 0f, 1f));

		if (Mathf.Abs (float_increment) >= limit) {
			// Inverti il senso di floating
			float_sign *= -1f;
		}

		float incr = float_sign * increment;
		float_increment += incr;

		this.gameObject.transform.Translate (new Vector3 (0f,0f,incr));
	}
}
