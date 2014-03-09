using UnityEngine;
using System.Collections;

public class RockBloc : Bloc {

	public float _VelocityToKill = 3.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player"){
			//Debug.Log("RockBloc collision with " + coll.gameObject.name + "--" + coll.gameObject.tag);
			if(rigidbody2D.velocity.magnitude > _VelocityToKill)
			{
				coll.gameObject.GetComponent<PhysicsPlayerTester>().SendMessage("Death");
			}
		} else if (coll.gameObject.name == "Void"){
			Destroy(gameObject);
		}
	}

}
