using UnityEngine;
using System.Collections;

public class PicsBloc : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name.Equals("PlayerTriggerHelper"))
		{
			CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
			if(character.collisionState.below)
			{
				character.GetComponent<PhysicsPlayerTester>().SendMessage("Death");
			}
		}
	}
}
