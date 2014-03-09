using UnityEngine;
using System.Collections;

public class RockBloc : Bloc {

	public float _VelocityToKill;
	Vector2 _LastVelocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_LastVelocity = rigidbody2D.velocity;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player"){
			//Debug.Log("RockBloc collision with " + coll.gameObject.name + "--" + coll.gameObject.tag);
			if( _LastVelocity.sqrMagnitude > _VelocityToKill){
				coll.gameObject.GetComponent<PhysicsPlayerTester>().SendMessage("Death");
				//Debug.Log("Bloc Lastvelocity sqr magn = (" + _LastVelocity.sqrMagnitude + ")");
			}
		} else if (coll.gameObject.name == "Void"){
			Destroy(gameObject);
		}
	}

}
