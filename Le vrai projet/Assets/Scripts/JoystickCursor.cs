using UnityEngine;
using System.Collections;

public class JoystickCursor : MonoBehaviour {

	public float moveSensitivity = 1.0f;
	public GameObject spawnableObject;

	private GameObject heldObject;
	private Vector3 objectCameraPosition;

	// Use this for initialization
	void Start () {

		//Screen.lockCursor = true;


	
	}
	
	// Update is called once per frame
	void Update () {
		
		//transform.Translate (Input.GetAxis ("Horizontal")*moveSensitivity, Input.GetAxis ("Vertical")*moveSensitivity, 0);

		transform.Translate (Input.GetAxis ("(P2) Mouse X")*moveSensitivity, Input.GetAxis ("(P2) Mouse Y")*moveSensitivity, 0);
		transform.Translate (Input.GetAxis ("(P2) HorizontalJoy")*moveSensitivity, Input.GetAxis ("(P2) VerticalJoy")*moveSensitivity, 0);
		objectCameraPosition = Camera.main.WorldToViewportPoint (transform.position);

		if (objectCameraPosition.x < 0)
			transform.Translate (1, 0, 0);

		if (objectCameraPosition.x > 1)
			transform.Translate (-1, 0, 0);

		if (objectCameraPosition.y < 0)
			transform.Translate (0, 1, 0);
		
		if (objectCameraPosition.y > 1)
			transform.Translate (0, -1, 0);
		

		transform.Translate (Input.GetAxis ("(P2) Mouse X")*moveSensitivity, Input.GetAxis ("(P2) Mouse Y")*moveSensitivity, 0);

		if (heldObject != null)
		{
			heldObject.transform.position = new Vector3 (Mathf.Lerp(heldObject.transform.position.x, transform.position.x, 0.5f),
			                                             Mathf.Lerp(heldObject.transform.position.y, transform.position.y, 0.5f),
			                                             0);
		}

		if (Input.GetButtonDown ("(P2) GrabReleaseObject") || Input.GetMouseButtonDown(0))
		{
			if (heldObject)
				releaseObject ();
			else
				grabObject ();
		}

	
	}

	void grabObject()
	{
		foreach (Collider2D c in Physics2D.OverlapPointAll(transform.position))
		{
			if (c.CompareTag("movable"))
			{
				heldObject = c.gameObject;

				heldObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

				return;
			}
		}
	}

	void releaseObject()
	{
		if (heldObject)
		{
			//Debug.Log ("d = " + d + ", q = " + q + ", D = " + D + ", r = " + r + ", choix = " + choix + ", position_nouvelle = " + position_nouvelle);

			heldObject.transform.position = new Vector3(calculateGrid (heldObject.transform.position.x, 3), 
			                                            calculateGrid (heldObject.transform.position.y, 3), 
			                                            heldObject.transform.position.z);

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
}
