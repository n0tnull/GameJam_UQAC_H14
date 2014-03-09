using UnityEngine;
using System.Collections;

public class IdleStamps : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (0, 15);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("stamps/Stamp" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (96f / 140f), transform.localScale.y * (96f / 165f), transform.localScale.z);

		GetComponent<BoxCollider2D> ().size = new Vector2 (1.4f, 1.6f);
	
	}
}
