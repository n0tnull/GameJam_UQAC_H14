using UnityEngine;
using System.Collections;

public class ElectricBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject == GameObject.Find ("Player"))
		{
			collider.gameObject.SendMessage("Death");
		}
	}
}
