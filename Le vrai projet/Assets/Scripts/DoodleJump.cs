using UnityEngine;
using System.Collections;

public class DoodleJump : Enemy
{
	public int _JumpTiming = 3;
	public int _JumpForce = 35;
	private AudioSource hop;

	// Use this for initialization
	new void Start()
	{
		base.Start();
		_SpawnPosition = transform.position;
		rigidbody2D.mass = 0.1f;
		hop= gameObject.GetComponent<AudioSource>();
	}

	// Make it jump
	protected override void evilThing()
	{
		hop.PlayOneShot (hop.clip);
		rigidbody2D.AddForce(new Vector2(0, _JumpForce));
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Bloc") {
			if (coll.gameObject.transform.position.y < transform.position.y) 
			{
				StartCoroutine(WaitingForJump());
			}
		}

		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PhysicsPlayerTester>().SendMessage("Death");	
		}
	}

	IEnumerator WaitingForJump()
	{
		yield return new WaitForSeconds(_JumpTiming);
		evilThing();
	}
}
