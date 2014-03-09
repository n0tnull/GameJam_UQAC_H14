using UnityEngine;
using System.Collections;

public class VictoryBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		collider2D.isTrigger = true;
		// Nothing !
	}
	
	// Update is called once per frame
	void Update () {
		// Nothing !
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.name == "PlayerTriggerHelper") {
			Debug.Log("Victory !");
			//TODO: Victory stuff here.
		}
	}

}
