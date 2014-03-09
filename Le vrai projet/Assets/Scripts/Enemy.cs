using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	protected Vector3 _SpawnPosition;
	private float initialX;
	private float initialY;

	// Use this for initialization
	protected virtual void Start () {
		gameObject.tag = "Enemy";
		rigidbody2D.fixedAngle = true;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		// Nothing !
	}

	public void SetInitialCoordinates(float x, float y)
	{
		initialX = x;
		initialY = y;
	}

	public virtual void Restart()
	{
		Vector2 temp = transform.position;
		temp.x = initialX;
		temp.y = initialY;
		transform.position = temp;
	}

	protected virtual void evilThing (){
		// Do evil thing here.
		// Killing players for exemple.
		// And don't forget to eat cookies !
	}

}
