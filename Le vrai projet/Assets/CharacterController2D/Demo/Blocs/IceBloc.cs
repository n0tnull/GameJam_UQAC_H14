using UnityEngine;
using System.Collections;

public class IceBloc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other.gameObject.name);
		if(other.gameObject.name == "PlayerTriggerHelper")
		{
			CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
			if(character.collisionState.below)
			{
				character.GetComponent<PhysicsPlayerTester>().SendMessage("OnIceEnter");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
		if (!character.collisionState.below) 
		{
			character.GetComponent<PhysicsPlayerTester>().SendMessage("OnIceExit");	
		}
	}

	void OnCollisionExit2D(Collision2D collider)
	{

	}
}
