using UnityEngine;
using System.Collections;

public class FallingStamps : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("stamps/StampFall", typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (80f / 140f), transform.localScale.y * (80f / 165f), transform.localScale.z);

		GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 1.6f);
	
	}
}
