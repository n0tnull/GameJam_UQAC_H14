using UnityEngine;
using System.Collections;

public class RockStickers : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (0, 3);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("gemSticker/gemSticker" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (96f / 100f), transform.localScale.y * (96f / 100f), transform.localScale.z);
	
	}
}
