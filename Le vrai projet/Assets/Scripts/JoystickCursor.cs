using UnityEngine;
using System.Collections;

public class JoystickCursor : MonoBehaviour {

	public float moveSensitivity = 1.0f;
	public GameObject squareObject, triangleObject;
	public Texture selectFrame, squareTexture, triangleTexture;
	public int maxBlock = 10;

	private int curBlock = 0;
	private GameObject heldObject;
	private Vector3 objectCameraPosition;
	private bool selectedTriangle = false;

	private GameObject player;
	private StartRace race;
	private Animator anim;

	public void resetBlockCount()
	{
		curBlock = 0;
	}

	public int getBlockCount()
	{
		return curBlock;
	}

	// Use this for initialization
	void Start () {

		//Screen.lockCursor = true;

		player = GameObject.Find("Player");
		race = player.GetComponent<StartRace>();
		anim = gameObject.GetComponent<Animator> ();
	
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
			
			if (heldObject)
			{
				heldObject.transform.position = new Vector3 (Mathf.Lerp (heldObject.transform.position.x, transform.position.x, 0.5f),
			                                 				 Mathf.Lerp (heldObject.transform.position.y, transform.position.y, 0.5f),
			                                 				 0);
			}
			
			if (Input.GetButtonDown ("(P2) GrabReleaseObject"))
			{
				if (heldObject)
					releaseObject ();
				else
					grabObject ();
			}

			if (Input.GetAxis ("(P2) Mouse ScrollWheel") != 0 || Input.GetButtonDown ("(P2) Select"))
			{
				if (!heldObject)
					selectedTriangle = !selectedTriangle;
			}

			if (Input.GetButtonDown ("(P2) RotateLeft") || Input.GetAxis ("(P2) Mouse ScrollWheel") > 0)
			{
				if (heldObject)
					heldObject.transform.Rotate (0, 0, 90);
			}
			else if (Input.GetButtonDown ("(P2) RotateRight") || Input.GetAxis ("(P2) Mouse ScrollWheel") < 0)
			{
				if (heldObject)
					heldObject.transform.Rotate (0, 0, -90);
			}

			if (Input.GetButtonDown ("(P2) ResetBlocks"))
			{
				resetBlockCount();
				BlockManager.Instance.ResetPlacedBlocks();
			}
			
			if (Input.GetButtonDown ("(P2) SpawnObject") && !heldObject)
				spawnObject ();

		}
	
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (Camera.main.pixelWidth - 120,
		                           Camera.main.pixelHeight - 120,
		                           100,
		                           100), selectFrame);

		Texture toDraw;
		if (selectedTriangle)
			toDraw = triangleTexture;
		else
			toDraw = squareTexture;

		GUI.DrawTexture (new Rect (Camera.main.pixelWidth - 110,
		                           Camera.main.pixelHeight - 110,
		                           80,
		                           80), toDraw);
	}

	void grabObject()
	{

		foreach (Collider2D c in Physics2D.OverlapPointAll(transform.position))
		{
			if (c.GetComponent<Bloc>().hasBeenPlaced)
			{
				anim.Play (Animator.StringToHash ("Grab"));
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
			anim.Play (Animator.StringToHash ("Cursor_Idle"));
			/*heldObject.transform.position = new Vector3(calculateGrid (heldObject.transform.position.x, 1), 
			                                            calculateGrid (heldObject.transform.position.y, 1), 
			                                            heldObject.transform.position.z);*/

			heldObject.collider2D.enabled = true;

			heldObject = null;
		}
	}

	/*int calculateGrid(double D, int d)
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
	}*/

	void spawnObject()
	{
		if(curBlock < maxBlock)
		{
			curBlock++;
			if (selectedTriangle)
				heldObject = Instantiate (triangleObject) as GameObject;
			else
				heldObject = Instantiate (squareObject) as GameObject;

			anim.Play (Animator.StringToHash ("Grab"));

			heldObject.collider2D.enabled = false;
			heldObject.GetComponent<Bloc> ().hasBeenPlaced = true;
			BlockManager.Instance.AddBlock(heldObject.GetComponent<Bloc> ());
			heldObject.transform.position = transform.position;
		}
	}
}
