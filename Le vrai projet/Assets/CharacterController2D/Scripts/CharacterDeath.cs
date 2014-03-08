using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour 
{
	private float starTimer = 0;
	private float starTimerAcc = 4;
	private bool timerStarted = false;
<<<<<<< HEAD
=======
	public float timeSinceDeath {get {return starTimerAcc;}}
>>>>>>> 90a3b731acad2af586e49a34c932adf91686ba23

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
<<<<<<< HEAD
=======
		if(timerStarted)
		{
			if(starTimerAcc > starTimer)
			{
				starTimerAcc -= Time.deltaTime;
			}
			else
			{
				starTimerAcc = 0;
				timerStarted = false;
				gameObject.GetComponent<StartRace>().switchTeam();
			}
		}
>>>>>>> 90a3b731acad2af586e49a34c932adf91686ba23
	}
}
