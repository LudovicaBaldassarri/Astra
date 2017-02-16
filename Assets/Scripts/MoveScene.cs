using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour {

	[SerializeField] private string loadLevel;
	public Canvas canvasPrimoLivello;


	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Player")) {
			SceneManager.LoadScene (loadLevel);
			canvasPrimoLivello.enabled = false;
		}
	}
}
