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
		if(other.gameObject.name == "PlayerTriggerHelper")
		{
			other.gameObject.SendMessage("OnIceExit");
		}
	}

	void OnCollisionExit2D(Collision2D collider)
	{

	}
}
