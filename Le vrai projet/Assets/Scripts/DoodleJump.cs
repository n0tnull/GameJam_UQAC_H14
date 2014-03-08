using UnityEngine;
using System.Collections;

public class DoodleJump : Enemy
{
	public int _JumpTiming = 3;
	public int _JumpForce = 35;
	// Use this for initialization
	void Start()
	{
		_SpawnPosition = transform.position;
		rigidbody2D.mass = 0.1f;
	}
	// Update is called once per frame
	void Update()
	{
		// Nothing !
	}

	// Make it jump
	protected void evilThing()
	{
		rigidbody2D.AddForce(new Vector2(0, _JumpForce));
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Bloc") {
			if(_SpawnPosition.y > transform.position.y) {
					StartCoroutine(WaitingForJump());
			}
		}
	}

	IEnumerator WaitingForJump()
	{
		yield return new WaitForSeconds(_JumpTiming);
		evilThing();
	}
}
