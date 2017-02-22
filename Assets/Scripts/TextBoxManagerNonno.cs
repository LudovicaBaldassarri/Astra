using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManagerNonno : MonoBehaviour {

	public GameObject textBox;
	public Text theText;
	public TextAsset textFile;
	public string[] textLines;
	public int currentLine;
	public int endAtLine;
	public bool isActive;

	// Use this for initialization
	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}

		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}


	void Update(){
		if (!isActive) {
			return;
		}

		theText.text = textLines [currentLine];

		if(Input.GetKeyDown(KeyCode.Return)){
			currentLine += 1;
		}
		if (currentLine >= endAtLine) {
			DisableTextBox ();
		}
	}


	public void EnableTextBox(){
		textBox.SetActive(true);
		isActive = true;
		Time.timeScale = 0;
	}


	public void DisableTextBox(){
		textBox.SetActive(false);
		isActive = false;
		Time.timeScale = 1;
	}

	// Use this to use different text files: pass a text file from somewhere else
	public void ReloadScript(TextAsset theText){
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));
		}
	}
}
