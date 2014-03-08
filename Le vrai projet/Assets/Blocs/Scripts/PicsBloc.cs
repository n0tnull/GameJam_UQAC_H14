using UnityEngine;
using System.Collections;

public class Pics : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject == GameObject.Find ("Player"))
		{
			if(collider.transform.position.y - 0.98 <= transform.position.y)
				collider.gameObject.SendMessage("Death");
		}
	}
}
