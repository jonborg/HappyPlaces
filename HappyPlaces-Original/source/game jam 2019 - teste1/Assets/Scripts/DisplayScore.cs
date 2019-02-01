using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
	private int previous;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		previous=0;
		UpdateText (previous);
	}
	
	// Update is called once per frame
	void Update () {
		if (previous != GameManager.points) {
			previous = GameManager.points;
			UpdateText (previous);
		}
	}

	void UpdateText(int score){
		scoreText.text = previous.ToString();			
	}
}
