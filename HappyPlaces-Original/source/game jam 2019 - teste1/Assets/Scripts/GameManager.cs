using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	public GamePlanner planner;
	public static int points;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);    

		DontDestroyOnLoad(gameObject);
		planner = GetComponent<GamePlanner>();
		points = 0;

		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
	}



	//Update is called every frame.
	void Update()
	{

	}

	public static void ChangePoints(int scorePoints){
		points =Mathf.Max(0,GameManager.points+scorePoints);
	}
}