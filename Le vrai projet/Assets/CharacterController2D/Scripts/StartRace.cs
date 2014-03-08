using UnityEngine;
using System.Collections;

public class StartRace : MonoBehaviour {

	private bool started = false;
	private bool inTimer = false;
	private float starTimer = 4;
	private float starTimerAcc = 0;
	private int team = 1;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started)
		{
			Debug.Log ("press spacebar to begin");
			if(Input.GetKeyDown (KeyCode.Space))
			{
				inTimer = true;
				Time.timeScale = 1;
				Debug.Log ("disabled");
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
					Debug.Log ("enabled");
					gameObject.GetComponent<CharacterController2D>().enabled = true;
					gameObject.GetComponent<PhysicsPlayerTester>().enabled = true;
					gameObject.rigidbody2D.isKinematic= true;

				}
			}


		}
	}

	void switchTeam()
}
