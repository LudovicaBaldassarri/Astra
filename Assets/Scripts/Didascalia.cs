using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Didascalia : MonoBehaviour {

	public GameObject astra;

	public float scaleSpeed = 4; 

	private bool animate = false;
	private float xScale;
	private float yScale;
	private float zScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (astra.transform);
		transform.rotation = Quaternion.Euler (-90, transform.rotation.eulerAngles.y, 90);


		if (animate) {
			xScale += scaleSpeed * Time.deltaTime;
			yScale += scaleSpeed * Time.deltaTime;
			zScale += scaleSpeed * Time.deltaTime;

			if (xScale > 2)
				xScale = 2;
			if (yScale > 2) {
				yScale = 2;
				animate = false;
			}
			if (zScale > 2)
				zScale = 2;

			this.transform.localScale = new Vector3 (xScale, yScale, zScale);
		}
	}
		

	void OnBecameVisible() {
		animate = true;
		this.transform.localScale = new Vector3 (0, 0, 0);
	}
}
