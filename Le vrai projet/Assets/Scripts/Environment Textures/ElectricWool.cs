using UnityEngine;
using System.Collections;

public class ElectricWool : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (0, 3);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("wool/wool" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (96f / 188f), transform.localScale.y * (96f / 137f), transform.localScale.z);

		GetComponent<BoxCollider2D> ().size = new Vector2 (1.9f, 1.35f);
	
	}
}
