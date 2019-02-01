using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoodMovement : MonoBehaviour {

	private float chance;
	private float chanceThres;
	private float speed;
	private int timeThres;
	private int flip;
	private float freq;
	private float amp;
	private float phase;
	private int levelIndex;

	void Start () {
		chance=Random.Range(0.0f,1.0f);
		flip = RandomCoin ();
		phase = Random.Range (-Mathf.PI, Mathf.PI);
		levelIndex = SceneManager.GetActiveScene().buildIndex;
		switch (levelIndex) {
		case 1:
			speed = Mathf.Min (2.0f + 0.5f * Time.timeSinceLevelLoad / 30, 3.0f);
			chanceThres = 2.0f;
			break;
		case 2:
			speed = Mathf.Min (2.0f + 0.5f * Time.timeSinceLevelLoad / 30, 3.0f);
			freq = 2;
			amp = 0.7f;
			chanceThres = -1.0f;
			break;
		case 3:
			speed = Mathf.Min (3.0f + 0.5f * Time.timeSinceLevelLoad / 30, 4.0f);
			freq = 2;
			amp = 0.7f;
			chanceThres = 0.5f;
			break;
		case 4:
			speed = Mathf.Min (4.0f + 0.5f * Time.timeSinceLevelLoad / 30, 5.0f);
			freq = 2;
			amp = 0.7f;
			chanceThres = 0.3f;
			break;
		}
	}

	void FixedUpdate () {
		
		if (chance < chanceThres) {
			MoveLinearDown ();
		} else {
			MoveSinusoidalDown ();	

		}
		if (transform.position.y<-2.0f){
			if(tag == "GoodMood")
			{

				Destroy(gameObject);
				GamePlanner.happySum = Mathf.Min (GamePlanner.happyTarget, GamePlanner.happySum + 1);
				GameManager.ChangePoints (100);
			}
			if(tag == "BadMood")
			{
				Destroy(gameObject);
				GamePlanner.happySum = Mathf.Max (0, GamePlanner.happySum - 2);
				GameManager.ChangePoints (-200);
			}
		}
	}


	void MoveLinearDown(){
		transform.position+= (new Vector3 (0, -speed * Time.deltaTime, 0.0f));

	}

	void MoveSinusoidalDown(){
		
		transform.position += new Vector3 (amp * Mathf.Sin (freq * Time.time) * Time.deltaTime, -speed * Time.deltaTime, 0.0f);
	}

	int RandomCoin(){
		if (Random.Range(0.0f,1.0f)>=0.5f){
			return 1;
		}else{
			return -1;
		}
	}

	void OnMouseDown(){
		Destroy (gameObject);
		if (tag == "GoodMood") {
			GameManager.ChangePoints (-400);
		}
		if (tag == "BadMood") {
			GameManager.ChangePoints (100);
		}
	}
}
