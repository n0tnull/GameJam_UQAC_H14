using UnityEngine;
using System.Collections;

public class VictoryBlock : MonoBehaviour 
{
	private float starTimer = 0;
	private float starTimerAcc = 4;
	private bool timerStarted = false;
	private TeamsScore score;
	public StartRace race;
	bool win = false;

	public bool HasWon { get { return win;} }
	public float timeSinceVictory {get {return starTimerAcc;}}

	// Use this for initialization
	void Start () 
	{
		race = GameObject.Find ("Player").GetComponent<StartRace>();
		collider2D.isTrigger = true;
		score = gameObject.GetComponent<TeamsScore> ();
		// Nothing !
	}
	
	// Update is called once per frame
	void Update () 
	{
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
				win = false;
				race.switchTeam();
			}
		}
	}

	void OnTriggerEnter2D (Collider2D coll) 
	{
		if (coll.gameObject.name == "PlayerTriggerHelper") 
		{
			score.getScore(race.team) += 600- starTimerAcc;
			win = true;
			timerStarted = true;
		}
	}

}
