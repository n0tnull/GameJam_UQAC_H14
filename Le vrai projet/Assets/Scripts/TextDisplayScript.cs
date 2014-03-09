using UnityEngine;
using System.Collections;

public class TextDisplayScript : MonoBehaviour {

	public float 	leftOffset = 100,
					heightOffset = 75;
	public GUISkin displaySkin;
	private GameObject player;
	private StartRace race;
	private PhysicsPlayerTester playerPhysics;
	private CharacterDeath playerDeath;
	private TeamsScore score;
	private GameObject fairy;
	private JoystickCursor screenCursor;
	private VictoryBlock victory;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		race = player.GetComponent<StartRace>();
		playerPhysics = player.GetComponent<PhysicsPlayerTester>();
		playerDeath = player.GetComponent<CharacterDeath>();
		score = player.GetComponent<TeamsScore>();
		fairy= GameObject.Find ("curseur");
		screenCursor = fairy.GetComponent<JoystickCursor> ();
		victory = GameObject.Find ("Victory").GetComponent<VictoryBlock>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(!race.RaceStarted && !race.TimerVisible)
		{
			GUI.Label(new Rect(Screen.width/2-120,Screen.height/2-75,300,100), 
			          "Équipe " + race.GetTeam() + ", Appuyer sur Espace pour demarrer");
		}

		if (race.TimeBeforeStart > 0 && race.TimerVisible){
			GUI.Label(new Rect(Screen.width/2-5,Screen.height/2-75,300,100), "" + (int) race.TimeBeforeStart);
		}

		if(playerPhysics.dead && race.GetTeam() == 1){
			GUI.Label(new Rect(Screen.width/2-75,Screen.height/2-heightOffset,175,100), 
			          "Vous etes morts!\nRespawn dans " + (int)playerDeath.timeSinceDeath + " secondes.");
		}

		if(playerPhysics.dead && race.GetTeam() == 2){
			GUI.Label(new Rect(Screen.width/2-50,Screen.height/2-heightOffset,150,100), 
			          "La partie est terminée.");
		}

		if(victory.HasWon && race.GetTeam() == 1)
		{
			GUI.Label(new Rect(Screen.width/2-75,Screen.height/2-heightOffset,175,100), 
			          "Vous avez réussi!\nRespawn dans " + (int)victory.timeSinceVictory + " secondes.");
		}

		if(victory.HasWon && race.GetTeam() == 2)
		{
			GUI.Label(new Rect(Screen.width/2-75,Screen.height/2-heightOffset,175,100), 
			          "Vous avez réussi! Partie terminée.");
		}

		GUI.Label(new Rect(Screen.width-50, 10, 100, 20), "" + score.getScore(race.GetTeam()) + " pts");
		GUI.Label(new Rect(Screen.width/2 -30, 10, 100, 50), "" + screenCursor.getBlockCount() + " sur 10 blocs");

		GUI.Label(new Rect(10, 10, 100, 20), "" + race.GameTimer.ToString("F2"));

		GUI.Label(new Rect(Screen.width-100, 25, 100, 20), "High Score: " + 
		          PlayerPrefs.GetFloat("HighScore/"+Application.loadedLevelName));

		if(GUI.Button (new Rect(0,Screen.height-25,110,20),"Reset blocs"))
		{
			BlockManager.Instance.ResetPlacedBlocks();
			screenCursor.resetBlockCount();
		}
	}

	void showCenterLabel(string s){

	}

}
