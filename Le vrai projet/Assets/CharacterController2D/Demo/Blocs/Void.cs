using UnityEngine;
using System.Collections;

public class Void : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Bloc")
		{
			other.gameObject.SetActive(false);
		}
	}

	void OnCollision2D(Collision2D other)
	{
		Debug.Log ("COLLIDE");
	}
}
