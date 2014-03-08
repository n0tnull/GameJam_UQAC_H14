using UnityEngine;
using System.Collections;

public class StartRace : MonoBehaviour {

	private bool started = false;
	private bool inTimer = false;
	private float starTimer = 4;
	private float starTimerAcc = 0;
	private int team = 1;
	GameObject startPoint;
	private GUIText _lostUI;

	// Use this for initialization
	void Start () 
	{
		_lostUI = GameObject.Find ("LostUI").GetComponent<GUIText>();
		startPoint = GameObject.Find ("Start");
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started)
		{
			if(Input.GetKeyDown (KeyCode.Space))
			{
				inTimer = true;
				Time.timeScale = 1;
				gameObject.GetComponent<CharacterController2D>().enabled = false;
				gameObject.GetComponent<PhysicsPlayerTester>().enabled = false;
				gameObject.rigidbody2D.isKinematic= false;
				//run gui animation
			}

			if(inTimer)
			{
				if(starTimerAcc < starTimer)
				{
					starTimerAcc += Time.deltaTime;
				}
				else
				{
					inTimer = false;
					started = true;
					starTimerAcc = 0;
					gameObject.GetComponent<CharacterController2D>().enabled = true;
					gameObject.GetComponent<PhysicsPlayerTester>().enabled = true;
					gameObject.rigidbody2D.isKinematic= true;

				}
			}
		}
	}

	void RestartTimer()
	{
		Time.timeScale = 0;
		starTimerAcc = 0;
		inTimer = false;
		started = false;
		gameObject.GetComponent<CharacterController2D>().enabled = false;
		gameObject.GetComponent<PhysicsPlayerTester>().enabled = false;
		gameObject.rigidbody2D.isKinematic= false;
	}

	public void switchTeam()
	{
		if(team == 1)
		{
			team = 2;
			Vector2 temp = transform.position;
			temp.x = startPoint.transform.position.x;
			temp.y = startPoint.transform.position.y;
			transform.position = temp;
			gameObject.GetComponent<PhysicsPlayerTester>().Revive();
			RestartTimer();
		}
		else if(team == 2)
		{
			_lostUI.enabled = true;
			_lostUI.text = "La partie est terminé!";
		}
	}
}
