using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(AudioSource))]

public class PlayVideo : MonoBehaviour {

	public MovieTexture movieSource;
	private AudioSource audioSource;

	public string prossimoLivello;

	// Use this for initialization
	void Start () {
		GetComponent<RawImage> ().texture = movieSource as MovieTexture;
		audioSource = GetComponent<AudioSource> ();
		//audioSource.clip = movieSource.audioClip;
		movieSource.Play ();
		//audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			SceneManager.LoadScene (prossimoLivello);
		}
	}
}
