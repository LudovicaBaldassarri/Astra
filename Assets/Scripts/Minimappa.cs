using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimappa : MonoBehaviour {

	public Transform Target;
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (Target.position.x, transform.position.y, Target.position.z);
		float yRot = Target.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Euler(90, yRot, 0);
	}
}
