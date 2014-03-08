using UnityEngine;
using System.Collections;

public class ElectricBloc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		CharacterController2D character = collider.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
		character.GetComponent<PhysicsPlayerTester>().SendMessage("Death");
	}
}
