using UnityEngine;
using System.Collections;

public class JoystickCursor_old : MonoBehaviour {

	public float moveSensitivity = 1.0f;
	private GameObject heldObject;
	private Vector3 objectOldPosition;

	// Use this for initialization
	void Start () {

		//Screen.lockCursor = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (Input.GetAxis ("Horizontal")*moveSensitivity, Input.GetAxis ("Vertical")*moveSensitivity, 0);

		//transform.Translate (Input.GetAxis ("Mouse X")*moveSensitivity, Input.GetAxis ("Mouse Y")*moveSensitivity, 0);

		if (heldObject != null)
		{
			heldObject.transform.position = new Vector3 (Mathf.Lerp(heldObject.transform.position.x, transform.position.x, 0.5f),
			                                             Mathf.Lerp(heldObject.transform.position.y, transform.position.y, 0.5f),
			                                             0);

			Rigidbody2D physics = heldObject.GetComponent<Rigidbody2D>();

			if (physics)
			{
				physics.velocity = heldObject.transform.position - objectOldPosition;
				objectOldPosition = heldObject.transform.position;
			}
		}

		if (Input.GetButtonDown ("Fire1")/* || Input.GetMouseButtonDown(0)*/)
		{
			if (heldObject)
				releaseObject ();
			else
				grabObject ();
		}

		if (Input.GetButtonDown ("Fire3")/* || Input.GetMouseButtonDown(1)*/)
			Debug.Log ("Nice, t'as pesé sur X.");

	}

	void grabObject()
	{
		foreach (Collider2D c in Physics2D.OverlapPointAll(transform.position))
		{
			if (c.CompareTag("movable"))
			{
				heldObject = c.gameObject;

				Rigidbody2D physics = heldObject.GetComponent<Rigidbody2D>();
				Collider2D collider = heldObject.GetComponent<Collider2D>();

				if (physics)
				{
					physics.gravityScale = 0.0f;
					physics.velocity = new Vector3(0,0,0);
					physics.angularVelocity = 0;
					if (collider) collider.enabled = false;
				}

				return;
			}
		}
	}

	void releaseObject()
	{
		if (heldObject)
		{
			Rigidbody2D physics = heldObject.GetComponent<Rigidbody2D>();
			Collider2D collider = heldObject.GetComponent<Collider2D>();
			
			if (physics)
			{
				physics.gravityScale = 1.0f;
				if (collider) collider.enabled = true;
			}

			heldObject = null;
		}
	}
}
