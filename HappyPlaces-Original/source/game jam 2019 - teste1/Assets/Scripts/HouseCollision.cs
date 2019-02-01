using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D obj)
	{
		if(obj.gameObject.tag == "GoodMood")
		{

			Destroy(obj.gameObject);
			GamePlanner.happySum = Mathf.Min (GamePlanner.happyTarget, GamePlanner.happySum + 1);
			GameManager.ChangePoints (100);
		}
		if(obj.gameObject.tag == "BadMood")
		{

			Destroy(obj.gameObject);
			GamePlanner.happySum = Mathf.Max (0, GamePlanner.happySum - 2);
			GameManager.ChangePoints (-200);
		}
	}
}
