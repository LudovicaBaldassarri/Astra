using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumen : MonoBehaviour {

	// Modificabili dall'esterno
	public float motion_height = 0.4f;
	public float motion_speed = 0.2f;
	public float rotation_speed = 4f;

	// Privati
	private float relative_height;
	private float sign;			// 1 == up, -1 == down

	// Use this for initialization
	void Start () {
		relative_height = 0;
		sign = 1;

		iTween.MoveTo (gameObject, iTween.Hash ("path", iTweenPath.GetPath ("test_path"), "time", 10, "easetype", iTween.EaseType.easeInOutSine));
	}
	
	// Update is called once per frame
	void Update () {

		// Rotazione sul proprio asse verticale
		float rot = rotation_speed * 100 * Time.deltaTime;
		transform.Rotate (new Vector3 (0f, 0f, rot));

		// Floating lungo l'asse verticale

		float trasl;

		// Inversione del floating
		if (Mathf.Abs (relative_height) > motion_height) {
			sign *= -1;
			trasl = sign * (Mathf.Abs(relative_height) - motion_height);

		} else {
			trasl = sign * Time.deltaTime * motion_speed;
		}
			
		// Aggiornamento dell'altezza relativa
		relative_height += trasl;

		// Traslazione
		this.gameObject.transform.Translate (new Vector3 (0f, 0f, trasl));
	}
}
