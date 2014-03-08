using UnityEngine;
using System.Collections;

public class ElectricBloc : Bloc {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		Debug.Log(other.gameObject.name);
//		if(other.gameObject.name == "PlayerTriggerHelper")
//		{
//			CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
//			character.GetComponent<PhysicsPlayerTester>().SendMessage("Death");
//		}
//	}
}
