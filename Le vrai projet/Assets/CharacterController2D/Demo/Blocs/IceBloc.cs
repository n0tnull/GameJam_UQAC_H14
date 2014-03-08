using UnityEngine;
using System.Collections;

public class IceBloc : Bloc {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "PlayerTriggerHelper")
		{
			CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();

			Vector3 left = new Vector3 (character.renderer.bounds.center.x - character.renderer.bounds.extents.x, character.renderer.bounds.center.y - character.renderer.bounds.extents.y);
			Vector3 right = new Vector3 (character.renderer.bounds.center.x + character.renderer.bounds.extents.x, character.renderer.bounds.center.y - character.renderer.bounds.extents.y);
			
			if (character.collisionState.below && (renderer.bounds.Contains(left) || renderer.bounds.Contains(right))) 
			{
				character.GetComponent<PhysicsPlayerTester>().SendMessage("OnIceEnter");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{

		CharacterController2D character = other.GetComponent<CC2DTriggerHelper>().getParentCharacterController();


		Vector3 left = new Vector3 (character.renderer.bounds.center.x - character.renderer.bounds.extents.x, character.renderer.bounds.center.y - character.renderer.bounds.extents.y);
		Vector3 right = new Vector3 (character.renderer.bounds.center.x + character.renderer.bounds.extents.x, character.renderer.bounds.center.y - character.renderer.bounds.extents.y);

		if (!character.collisionState.below && (!renderer.bounds.Contains(left)&&!renderer.bounds.Contains(right))) 
		{
			character.GetComponent<PhysicsPlayerTester>().SendMessage("OnIceExit");	
		}
	}

	void OnCollisionExit2D(Collision2D collider)
	{

	}
}
