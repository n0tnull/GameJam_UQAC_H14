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
		Debug.Log ("OnDisappearCollision");
		if(other.gameObject.name == "PlayerTriggerHelper")
		{
			CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
			character.GetComponent<PhysicsPlayerTester>().SendMessage("Disappear");
		}
	}
}
