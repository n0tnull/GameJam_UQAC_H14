using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartRace : MonoBehaviour {

	private bool started = false;
	private bool inTimer = false;
	private float starTimer = 4;
	private float starTimerAcc = 0;
	public int team = 1;
	GameObject startPoint;
	private float playerTimer = 0;
	private bool playerTimerStarted = false;
	private TeamsScore score;
	private JoystickCursor screenCursor;
	private bool ending = false;

	//Zone des sprites
	public Sprite stamp1;

	// Use this for initialization
	void Start () 
	{
		startPoint = GameObject.Find ("Start");
		Time.timeScale = 0;
		score = gameObject.GetComponent<TeamsScore> ();
		InitialiseBlocs();
		InitialiseEnemies();
	}

	public bool RaceStarted {get {return started;} }
	public float TimeBeforeStart {get {return starTimer-starTimerAcc+1;}}
	public bool TimerVisible {get {return inTimer;}}
	public float GameTimer { get { return playerTimer;} }

	void InitialiseBlocs()
	{
		foreach(GameObject objet in GameObject.FindGameObjectsWithTag("Bloc"))
		{
			Bloc bloc = objet.GetComponent<Bloc>();
			if(bloc != null)
			{
				/*Sprite sprite = new Sprite();
				Rect rect = new Rect(0, 0, bloc.renderer.bounds.size.x*100, bloc.renderer.bounds.size.y*100);
				sprite = Sprite.Create(stamp1.texture, rect,new Vector2(0,0));

				bloc.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;*/

				bloc.SetInitialCoordinates(bloc.transform.position.x,bloc.transform.position.y);
				BlockManager.Instance.AddBlock(bloc);
			}
		}
	}

	void InitialiseEnemies()
	{
		foreach(GameObject objet in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			Enemy enemy = objet.GetComponent<Enemy>();
			if(enemy != null)
			{
				enemy.SetInitialCoordinates(enemy.transform.position.x,enemy.transform.position.y);
				EnemyManager.Instance.AddEnemy(enemy);
			}
		}
	}

	void RestartLevel()
	{
		EnemyManager.Instance.Restart();
		BlockManager.Instance.Restart();
		GameObject.Find ("curseur").GetComponent<JoystickCursor> ().resetBlockCount ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!started)
		{
			if(Input.GetKeyDown (KeyCode.Space) || Input.GetButtonDown("(P1) Jump"))
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
					playerTimerStarted = true;
					GameObject.Find ("Main Camera").GetComponent<AudioSource>().Play();
				}
			}
		}
		if(playerTimerStarted)
		{
			playerTimer += Time.deltaTime;
		}
	}

	void RestartTimer()
	{
		playerTimer = 0;
		Time.timeScale = 0;
		starTimerAcc = 0;
		inTimer = false;
		started = false;
		gameObject.GetComponent<CharacterController2D>().enabled = false;
		gameObject.GetComponent<PhysicsPlayerTester>().enabled = false;
		gameObject.rigidbody2D.isKinematic= false;
	}

	public void StopTimer()
	{
		playerTimerStarted = false;
	}

	public void switchTeam()
	{
		GameObject.Find ("Main Camera").GetComponent<AudioSource>().Stop ();
		if(team == 1)
		{
			if(GameState.score1 ==0)
			{
				GameState.score1= score.getScore(1);
				GameState.time1=starTimerAcc;
			}
			team = 2;
			Vector2 temp = transform.position;
			temp.x = startPoint.transform.position.x;
			temp.y = startPoint.transform.position.y;
			transform.position = temp;
			gameObject.GetComponent<PhysicsPlayerTester>().Revive();
			RestartLevel();
			RestartTimer();
		}
		else if(team == 2)
		{
			if(GameState.score1 ==0)
			{
				GameState.score2= score.getScore(2);
				GameState.time2=starTimerAcc;
			}
			CheckHighScore();
			StartCoroutine(Wait());
			Application.LoadLevel ("win");
		}
	}

	void CheckHighScore()
	{
		float littleHighScore = (GameState.score1 >= GameState.score2) ? GameState.score1 : GameState.score2;
		float highScore = PlayerPrefs.GetFloat("HighScore/"+Application.loadedLevelName);
		if(littleHighScore > highScore)
			PlayerPrefs.SetFloat("HighScore/"+Application.loadedLevelName,littleHighScore);
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(5);
	}

	public int GetTeam()
	{
		return team;
	}

	/*void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), ""+ playerTimer.ToString("F2"));
	}*/
}
