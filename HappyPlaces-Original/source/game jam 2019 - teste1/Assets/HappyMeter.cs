using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyMeter : MonoBehaviour {
	private Image greenBar;
	private float previous;
	// Use this for initialization
	void Start () {
		greenBar = GetComponent<Image> ();
		previous = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (previous != GamePlanner.happySum) {
			previous = (float)GamePlanner.happySum;
			greenBar.fillAmount=previous/GamePlanner.happyTarget;
		}
	}
}
