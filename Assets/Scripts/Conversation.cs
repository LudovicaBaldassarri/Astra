using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation : MonoBehaviour {

	[System.Serializable]
	public class Node {
		public string dialogueText;
		public Node[] responses;
	}

	public Node startNode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
