using UnityEngine;
using System.Collections;

public class SpikePaper : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (0, 3);
		BoxCollider2D c = GetComponent<BoxCollider2D> ();

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("paper-spike/paper-spike" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (96f / 3888f), transform.localScale.y * (96f / 2592f), transform.localScale.z);

		c.size = new Vector2 (38.9f, 17f);
		c.center = new Vector2 (0f, -4.5f);
	
	}
}
