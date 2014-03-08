using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour 
{
	private float starTimer = 0;
	private float starTimerAcc = 4;
	private bool timerStarted = false;

	// Use this for initialization
	void Start () 
	{
	}

	public void OnDeath()
	{
		gameObject.GetComponent<StartRace>().StopTimer();
		timerStarted = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
