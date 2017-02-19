using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumenStages : MonoBehaviour {

	public GameObject lumen;
	public string pathName;
	public float pathTime;

	private bool lumenFollow;

	void OnTriggerEnter() {
		this.GetComponent<BoxCollider> ().enabled = false;
		iTween.MoveTo (lumen, iTween.Hash ("path", iTweenPath.GetPath (pathName), "time", pathTime, "easetype", iTween.EaseType.easeInOutSine));
	}
}
