using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxigenRefill : MonoBehaviour {

	public delegate void InsideNavAction();
	public static event InsideNavAction onInsideNav;

	void OnTriggerStay() {
		onInsideNav ();
	}
}
