using UnityEngine;
using System.Collections;

public class IceTrianglePaint : MonoBehaviour {

	// Use this for initialization
	void Start () {

		int randomTextureID = Random.Range (1, 7);

		GetComponent<SpriteRenderer>().sprite = Resources.Load ("paint/triangle/paint" + randomTextureID, typeof(Sprite)) as Sprite;

		transform.localScale = new Vector3 (transform.localScale.x * (512f / 458f), transform.localScale.y * (512f / 495f), transform.localScale.z);

		Destroy (GetComponent<PolygonCollider2D> ());

		gameObject.AddComponent<PolygonCollider2D> ();
	
	}
}
