using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Didascalia : MonoBehaviour {

	public GameObject astra;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (astra.transform);
		transform.rotation = Quaternion.Euler (0, transform.rotation.eulerAngles.y, 90);
	}
}
