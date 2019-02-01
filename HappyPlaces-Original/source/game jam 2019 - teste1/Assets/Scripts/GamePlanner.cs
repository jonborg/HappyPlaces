using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlanner : MonoBehaviour {
	public GameObject[] prefabs;
	public GameObject[] emitters;


	// Use this for initialization
	private int levelIndex;
	private int min;
	private int max;
	private int startMin;
	private int startMax;
	private int minDiv;
	private int maxDiv;
	private int minMax;
	private int maxMax;

	private int timeThres;
	public static int happySum=0;
	public static int happyTarget;
	private int wavesCompleted;
	private float secondsCounter;


	void Start () {
		levelIndex = SceneManager.GetActiveScene().buildIndex;
		switch(levelIndex){
		case 1:
			minDiv = 15;
			maxDiv = 10;

			startMin = 1;
			startMax = 1;
			minMax = 2;
			maxMax = 3;

			timeThres = 3;
			happyTarget = 15;

			GenWave (startMin, startMax);
			break;
		case 2:
			minDiv = 15;
			maxDiv = 10;

			startMin = 1;
			startMax = 1;
			minMax = 2;
			maxMax = 3;

			timeThres = 3;
			happyTarget = 30;

			GenWave (startMin, startMax);
			break;
		case 3:
			minDiv = 15;
			maxDiv = 10;

			startMin = 2;
			startMax = 2;
			minMax = 3;
			maxMax = 4;

			timeThres = 2;
			happyTarget = 40;
			GenWave (startMin, startMax);
			break;
		case 4:
			minDiv = 15;
			maxDiv = 10;


			startMin = 3;
			startMax = 3;
			minMax = 4;
			maxMax = 5;

			timeThres = 2;
			happyTarget = 60;
			GenWave (startMin, startMax);
			break;
		}


	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		secondsCounter += Time.deltaTime;
		if (secondsCounter > timeThres) {
			wavesCompleted += 1;
			min = Mathf.Min(minMax,startMin + wavesCompleted*(int)secondsCounter / minDiv);
			max = Mathf.Min(maxMax,startMax + wavesCompleted*(int)secondsCounter / maxDiv);

			GenWave (min, max);
			secondsCounter = 0;
		}
		
		if (happySum >= happyTarget) {
			SceneManager.LoadScene (levelIndex + 1);
		} 

	}


	void GenWave(int min, int max){
		int idx;
		int num = Random.Range (min,max+1);
		List<GameObject> emittersList = RandomList (num);

		for (int i = 0; i < num; i++) {
			idx = Random.Range (0, 2);
			GenObject (prefabs [idx], emittersList [i]);

		}
	}


	void GenObject(GameObject prefab,GameObject emitter){
		Instantiate(prefab, emitter.transform.position, Quaternion.identity);
	}


	List<GameObject> RandomList(int num){
		int idx;
		int listSize = emitters.Length;
		int rmv = emitters.Length - num;
		List<GameObject> emittersList = new List<GameObject> (emitters);

		for (int i = 0; i < rmv; i++) {
			idx = Random.Range (0, listSize);
			emittersList.RemoveAt (idx);
			listSize -= 1;
		}
		return emittersList;
	}


}
