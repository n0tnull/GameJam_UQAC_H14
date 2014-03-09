using UnityEngine;
using System.Collections;

public class IcePaint : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (1, 7);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("paint/paint" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (96f / 513f), transform.localScale.y * (96f / 179f), transform.localScale.z);

		GetComponent<BoxCollider2D> ().size = new Vector2 (5.13f, 1.79f);
	
	}
}
