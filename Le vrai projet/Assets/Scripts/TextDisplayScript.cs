using UnityEngine;
using System.Collections;

public class TextDisplayScript : MonoBehaviour {

	public float 	leftOffset = 100,
					heightOffset = 75;
	public GUISkin displaySkin;
	private GameObject player;
	private StartRace race;
	private PhysicsPlayerTester playerPhysics;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		race = player.GetComponent<StartRace>();
		playerPhysics = player.GetComponent<PhysicsPlayerTester>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(!race.RaceStarted && !race.TimerVisible)
		{
			GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-75,300,100), "Appuyer sur Espace pour demarrer");
		}

		if (race.TimeBeforeStart > 0 && race.TimerVisible){
			GUI.Label(new Rect(Screen.width/2-5,Screen.height/2-75,300,100), "" + (int) race.TimeBeforeStart);
		}

		if(playerPhysics.dead){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2-heightOffset,150,100), "Vous etes mort !");
		}

	}

	void showCenterLabel(string s){

	}

}
