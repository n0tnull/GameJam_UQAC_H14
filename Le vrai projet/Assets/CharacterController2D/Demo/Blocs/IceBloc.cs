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
			if(other.GetComponent<CC2DTriggerHelper>().getParentCharacterController().collisionState.below)
			{
				Debug.Log("ok");
				other.gameObject.SendMessage("OnIceEnter");
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
<<<<<<< HEAD
		CharacterController2D character = collider.GetComponent<CC2DTriggerHelper>().getParentCharacterController();
		if (!character.collisionState.below) 
		{
			character.GetComponent<PhysicsPlayerTester>().SendMessage("OnIceExit");	
		}
=======
		if(other.gameObject.name == "PlayerTriggerHelper")
		{
			other.gameObject.SendMessage("OnIceExit");
		}
	}

	void OnCollisionExit2D(Collision2D collider)
	{
>>>>>>> 6a1e7982d5d0c96baebab0bf391389dbf9df4bdd

	}
}
