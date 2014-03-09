using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	public static int score1;
	public static int score2;
	public static float time1;
	public static float time2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetScore(int team)
	{
		if(team == 1)
			return score1;
		if(team == 2)
			return score2;
		return 0;
	}

	public float GetTime(int team)
	{
		if(team == 1)
			return time1;
		if(team == 2)
			return time2;
		return 0;
	}
}
