using UnityEngine;
using System.Collections;

public class CharacterDeath : MonoBehaviour 
{
	private float starTimer = 0;
	private float starTimerAcc = 4;
	private bool timerStarted = false;
	private GUIText _lostUI;

	// Use this for initialization
	void Start () 
	{
		_lostUI = GameObject.Find ("LostUI").GetComponent<GUIText>();
	}

	public void OnDeath()
	{
		timerStarted = true;
		_lostUI.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timerStarted)
		{
			if(starTimerAcc > starTimer)
			{
				_lostUI.text = "Vous avez perdu!\nRespawn dans " + (int)starTimerAcc + " secondes.";
				starTimerAcc -= Time.deltaTime;
			}
			else
			{
				starTimerAcc = 0;
				timerStarted = false;
				_lostUI.text = "";
				_lostUI.enabled = false;
				gameObject.GetComponent<StartRace>().switchTeam();
			}
		}
	}
}
