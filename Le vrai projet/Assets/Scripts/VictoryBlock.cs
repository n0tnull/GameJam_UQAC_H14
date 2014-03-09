using UnityEngine;
using System.Collections;

public class VictoryBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.gravityScale = 0;
		collider2D.isTrigger = true;
		// Nothing !
	}
	
	// Update is called once per frame
	void Update () {
		// Nothing !
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log("Victory !");
			Application.LoadLevel ("win");
		}
	}

}
