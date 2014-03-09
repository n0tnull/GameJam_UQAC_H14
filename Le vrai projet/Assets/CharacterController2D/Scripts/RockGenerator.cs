using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour 
{
	public float starTimer = 4;
	private float starTimerAcc = 0;
	public GameObject prefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(starTimerAcc > starTimer)
		{
			GameObject rock = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
			rock.GetComponent<Bloc>().hasBeenPlaced = true;
			BlockManager.Instance.AddBlock(rock.GetComponent<Bloc>());
			starTimerAcc = 0;
		}
		else
		{
			starTimerAcc += Time.deltaTime;
		}
	}


}
