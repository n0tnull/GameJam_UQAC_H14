using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	protected Vector3 _SpawnPosition;

	// Use this for initialization
	void Start () {
		gameObject.tag = "Enemy";
	}
	
	// Update is called once per frame
	void Update () {
		// Nothing !
	}

	virtual protected void evilThing (){
		// Do evil thing here.
		// Killing players for exemple.
		// And don't forget to eat cookies !
	}

}
