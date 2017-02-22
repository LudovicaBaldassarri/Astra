using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interzone : MonoBehaviour {

	public int numeroSfere;
	public string nomeLivelloSuccessivo;
	public string nomeLivelloPrecedente;

	private string prossimoLivello;

	// Use this for initialization
	void Awake () {

		int sfereRaccolte = PlayerPrefs.GetInt ("energy");

		if (sfereRaccolte >= numeroSfere) {
			prossimoLivello = nomeLivelloSuccessivo;
			this.gameObject.GetComponent<Text>().text = "Hai fatto il pieno di energia per NAV!\n Premi invio per il livello successivo.";
		} else {
			prossimoLivello = nomeLivelloPrecedente;
			this.gameObject.GetComponent<Text>().text = "NAV non ha energia senza sfere.\n Premi invio e cerca di raccoglierle tutte.";
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			SceneManager.LoadScene (prossimoLivello);
			
	}
}
