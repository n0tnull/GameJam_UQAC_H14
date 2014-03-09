using UnityEngine;
using System.Collections;

public class FallingTriangleStamps : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("stamps/triangle/StampFall", typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (512f / 140f), transform.localScale.y * (512f / 165f), transform.localScale.z);

		Destroy (GetComponent<PolygonCollider2D> ());

		gameObject.AddComponent<PolygonCollider2D> ();
	
	}
}
