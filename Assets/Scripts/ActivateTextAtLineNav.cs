using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLineNav : MonoBehaviour {

	public TextAsset theText;
	public int startLine;
	public int endLine;
	public TextBoxManagerNav theTextBox;
	public bool destroyWhenFinished;
	public string[] textLines;

	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManagerNav> ();

		if (theText != null) {
			textLines = (theText.text.Split ('\n'));
			endLine = textLines.Length;
		}
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){
		if (other.name == "Astra") {
			theTextBox.ReloadScript (theText);
			theTextBox.currentLine = startLine;
			theTextBox.endAtLine = endLine;
			theTextBox.EnableTextBox ();

			if (destroyWhenFinished) {
				Destroy (gameObject);
			}
		}
	}
}
