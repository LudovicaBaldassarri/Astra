using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLineNonno : MonoBehaviour {

	public TextAsset theText;
	public int startLine;
	public int endLine;
	public TextBoxManagerNonno theTextBox;
	public bool destroyWhenFinished;
	public string[] textLines;

	// Use this for initialization
	void Start () {
		theTextBox = FindObjectOfType<TextBoxManagerNonno> ();

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
