using UnityEngine;
using System.Collections;

public class FallingBloc : MonoBehaviour 
{
	bool shaking;
	bool falling;
	bool secondState;
	float pos;
	float increment;
	int cpt;

	// Use this for initialization
	void Start () 
	{
		increment = 0.1f;
		shaking = false;
		falling = false;
		secondState = false;
		cpt = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(shaking)
		{
			Vector2 temp = transform.position;
			temp.x = transform.position.x + increment;
			transform.position = temp;
			pos += increment;
			if(pos >= 0.3f || pos <= -0.3f)
			{
				increment *= -1;
				cpt++;
			}
			if(cpt == 4 && pos < 0.1f && pos > -0.1f)
			{
				shaking = false;
				falling = true;
				secondState = true;
			}
		}
		if(falling)
		{
			Vector2 temp = transform.position;
			temp.y = transform.position.y + -0.1f;
			transform.position = temp;
		}
	}

	public void Shake()
	{
		shaking = true;
	}

	/*void OnCollisionEnter2D(Collision2D collider)
	{
		if(secondState)
			falling = false;
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		if(secondState)
			falling = true;
	}*/

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.name.Equals("PlayerTriggerHelper"))
		{
			if(collider.GetComponent<CC2DTriggerHelper>().getParentCharacterController().collisionState.below)
			{
				Debug.Log ("Par le dessus");
				//shaking = true;
			}
		}
	}
}
