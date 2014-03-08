using UnityEngine;
using System.Collections;

public class AngryBirds : Enemy {

	public int _PatrolRadius = 5;
	public float _Speed = 12;
	bool movingLeft;

	// Use this for initialization
	void Start () {
		if (!rigidbody2D.isKinematic){
			rigidbody2D.isKinematic = true;
		}
		_SpawnPosition = transform.position;
		movingLeft = Random.Range(0, 2) <= 0.5;
	}
	
	// Update is called once per frame
	void Update () {
		evilThing ();
	}

	
	// Make it patrol
	protected void evilThing (){

		if (_SpawnPosition.x + _PatrolRadius < transform.position.x){
			movingLeft = true;
			//transform.position = new Vector3(transform.position.x - _Speed * Time.deltaTime, _SpawnPosition.y, _SpawnPosition.z );
		} else if (_SpawnPosition.x - _PatrolRadius > transform.position.x){
			movingLeft = false;
			//transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime, _SpawnPosition.y, _SpawnPosition.z );
		}

		if (movingLeft) {
			transform.position = new Vector3 (transform.position.x - _Speed * Time.deltaTime, _SpawnPosition.y, _SpawnPosition.z);
		} else {
			transform.position = new Vector3(transform.position.x + _Speed * Time.deltaTime, _SpawnPosition.y, _SpawnPosition.z );
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bloc") {
					movingLeft = !movingLeft;
			}
	}

}
