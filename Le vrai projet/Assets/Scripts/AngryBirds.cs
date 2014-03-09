using UnityEngine;
using System.Collections;

public class AngryBirds : Enemy {

	public int _PatrolRadius = 5;
	public float _Speed = 12;
	bool movingLeft;
	private Quaternion _rotation;
	Vector2 _Pos;

	// Use this for initialization
	new void Start () {
		_rotation = new Quaternion(0,0,0,0);
		base.Start();
		rigidbody2D.gravityScale = 0;
		_Pos = _SpawnPosition = transform.position;
		movingLeft = Random.Range(0, 2) <= 0.5;
	}
	
	// Update is called once per frame
	new void Update () {
		evilThing ();
	}

	
	// Make it patrol
	protected override void evilThing (){

		if (_SpawnPosition.x + _PatrolRadius <= transform.position.x){
			movingLeft = true;
			_rotation.y = 0;
			transform.rotation = _rotation;
		} else if (_SpawnPosition.x - _PatrolRadius > transform.position.x){
			movingLeft = false;
			_rotation.y = 180;
			transform.rotation = _rotation;
		}

		if (movingLeft) {
			rigidbody2D.velocity = new Vector2(-_Speed, 0);
		} else {
			rigidbody2D.velocity = new Vector2(_Speed, 0);
		}

		// On le garde a la meme hauteur...
		if(transform.position.y != _SpawnPosition.y){
			_Pos.x = transform.position.x;
			transform.position = _Pos;
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
//		Debug.Log("collision of AngryBirds with " + coll.gameObject.tag);

		if (coll.gameObject.tag == "Bloc") {

				if (transform.rotation.y == 0){
					_rotation.y = 180;
					transform.rotation = _rotation;
				} else {
					_rotation.y = 0;
					transform.rotation = _rotation;
				}
				movingLeft = !movingLeft;
		}
		if(coll.gameObject.tag == "Player")
		{
//			Debug.Log(  coll.gameObject.name );
			coll.gameObject.GetComponent<PhysicsPlayerTester>().SendMessage("Death");	
		}
	}

}
