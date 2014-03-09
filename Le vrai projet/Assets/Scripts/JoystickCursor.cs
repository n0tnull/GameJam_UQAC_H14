using UnityEngine;
using System.Collections;

public class JoystickCursor : MonoBehaviour {

	public float moveSensitivity = 1.0f;
	public GameObject[] spawnableObjects;

	public int blockLimit = 10;
	private int blockCount =0;

	public Texture selectFrame;

	private GameObject heldObject;
	private Vector3 objectCameraPosition;
	private int selectedIndex = 0;

	private GameObject player;
	private StartRace race;

	private Animator _animator;

	public int getBlockCount()
	{
		return blockCount;
	}

	// Use this for initialization
	void Start () {

		_animator = gameObject.GetComponent<Animator>();
		//Screen.lockCursor = true;

		player = GameObject.Find("Player");
		race = player.GetComponent<StartRace>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (race.RaceStarted)
		{
			transform.Translate (Input.GetAxis ("(P2) Mouse X") * moveSensitivity, Input.GetAxis ("(P2) Mouse Y") * moveSensitivity, 0);
			transform.Translate (Input.GetAxis ("(P2) HorizontalJoy") * moveSensitivity, Input.GetAxis ("(P2) VerticalJoy") * moveSensitivity, 0);
			
			objectCameraPosition = Camera.main.WorldToViewportPoint (transform.position);
			
			if (objectCameraPosition.x < 0)
				transform.Translate (1, 0, 0);
			
			if (objectCameraPosition.x > 1)
				transform.Translate (-1, 0, 0);
			
			if (objectCameraPosition.y < 0)
				transform.Translate (0, 1, 0);
			
			if (objectCameraPosition.y > 1)
				transform.Translate (0, -1, 0);
			
			transform.Translate (Input.GetAxis ("(P2) Mouse X") * moveSensitivity, Input.GetAxis ("(P2) Mouse Y") * moveSensitivity, 0);
			
			if (heldObject)
			{
				heldObject.transform.position = new Vector3 (Mathf.Lerp (heldObject.transform.position.x, transform.position.x, 0.5f),
			                                 				 Mathf.Lerp (heldObject.transform.position.y, transform.position.y, 0.5f),
			                                 				 0);
			}
			
			if (Input.GetButtonDown ("(P2) GrabReleaseObject"))
			{
				if (heldObject)
				{
					_animator.Play( Animator.StringToHash( "Cursor_Idle" ) );
					releaseObject ();
				}
				else
					grabObject ();
			}
			
			if (Input.GetButtonDown ("(P2) SpawnObject") && !heldObject)
			{
				if(blockCount <= blockLimit)
				{
					_animator.Play( Animator.StringToHash( "Grab" ) );
					spawnObject ();
				}
			}

		}
	
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (Camera.main.pixelWidth - 120,
		                           Camera.main.pixelHeight - 120,
		                           100,
		                           100), selectFrame);

		GUI.DrawTexture (new Rect (Camera.main.pixelWidth - 110,
		                           Camera.main.pixelHeight - 110,
		                           90,
		                           90), spawnableObjects [selectedIndex].renderer.material.mainTexture);
	}

	void grabObject()
	{

		foreach (Collider2D c in Physics2D.OverlapPointAll(transform.position))
		{
			if (c.GetComponent<Bloc>().hasBeenPlaced)
			{

				heldObject = c.gameObject;

				heldObject.collider2D.enabled = false;
				heldObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

				return;
			}
		}
	}

	void releaseObject()
	{
		if (heldObject)
		{
			heldObject.transform.position = new Vector3(calculateGrid (heldObject.transform.position.x, 1), 
			                                            calculateGrid (heldObject.transform.position.y, 1), 
			                                            heldObject.transform.position.z);

			heldObject.collider2D.enabled = true;

			heldObject = null;
		}
	}

	int calculateGrid(double D, int d)
	{
		int q, position_nouvelle;
		double r, choix;
		
		q = (int)D / d;
		r = D % d;
		
		choix = d / 2;
		
		if (r < choix)
		{
			position_nouvelle = (q*d);
		}
		else
		{
			position_nouvelle = (q*d)+d;
		}

		return position_nouvelle;
	}

	void spawnObject()
	{
		blockCount++;
		heldObject = Instantiate (spawnableObjects [selectedIndex]) as GameObject;
		heldObject.collider2D.enabled = false;
		heldObject.GetComponent<Bloc> ().hasBeenPlaced = true;
		heldObject.transform.position = transform.position;
	}
}
