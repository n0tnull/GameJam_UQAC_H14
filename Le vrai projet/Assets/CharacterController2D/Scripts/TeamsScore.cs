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
		Debug.Log (score [gameObject.GetComponent<StartRace> ().team - 1]);
	}

	float getScore(int team)
	{
		return score[team];
	}
}
