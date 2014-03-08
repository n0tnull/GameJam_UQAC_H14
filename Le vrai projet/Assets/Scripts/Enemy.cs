using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	protected Vector3 _SpawnPosition;

	// Use this for initialization
	protected virtual void Start () {
		gameObject.tag = "Enemy";
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		// Nothing !
	}

	protected virtual void evilThing (){
		// Do evil thing here.
		// Killing players for exemple.
		// And don't forget to eat cookies !
	}

}
