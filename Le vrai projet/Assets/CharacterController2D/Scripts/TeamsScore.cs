using UnityEngine;
using System.Collections;

public class TeamsScore : MonoBehaviour {

	private Vector3 begin;
	private float[] score = new float[2];
	// Use this for initialization
	void Start () {
		begin = GameObject.Find ("Start").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		score[gameObject.GetComponent<StartRace>().team-1] = transform.position.x - begin.x;
	}

	public int getScore(int team)
	{
		return  (int)score[team-1];
	}

	public void setScore(int newScore,int team)
	{
		score[team-1] = newScore;
	}
}
