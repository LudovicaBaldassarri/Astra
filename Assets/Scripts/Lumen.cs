using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumen : MonoBehaviour {

	// Modificabili dall'esterno
	public float motion_height = 0.2f;
	public float motion_speed = 0.02f;
	public float rotaion_speed = 0.02f;

	// Privati
	private float relative_height;
	private float sign;			// 1 == up, -1 == down

	// Use this for initialization
	void Start () {
		relative_height = 0;
		sign = 1;
	}
	
	// Update is called once per frame
	void Update () {

		// Rotazione sul proprio asse verticale
		float rot = rotaion_speed * Time.deltaTime;
		this.gameObject.transform.Rotate (new Vector3 (0f, 0f, rot));

		// Floating lungo l'asse verticale
		if (Mathf.Abs(relative_height) >= motion_height) {
			// Inverti il senso di floating
			sign *= -1;
		} 

		float trasl = sign * Time.deltaTime * motion_speed;
		relative_height += trasl;

		this.gameObject.transform.Translate (new Vector3 (0f, 0f, trasl));
	}
}
