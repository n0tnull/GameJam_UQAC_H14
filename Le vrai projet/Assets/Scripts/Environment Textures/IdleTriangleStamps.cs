using UnityEngine;
using System.Collections;

public class IdleTriangleStamps : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (0, 15);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("stamps/triangle/Stamp" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (512f / 140f), transform.localScale.y * (512f / 165f), transform.localScale.z);

		Destroy (GetComponent<PolygonCollider2D> ());

		gameObject.AddComponent<PolygonCollider2D> ();
	
	}
}
