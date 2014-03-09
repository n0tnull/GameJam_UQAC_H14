using UnityEngine;
using System.Collections;

public class win : MonoBehaviour {

	public GUISkin displaySkin;
	
	private float 	_btnWidth = 180,
	_btnHeight = 30,
	_heightOffset = 40,
	_offsetWithTitle = 50,
	_rightOffset = 40;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI(){
		
		GUI.skin = displaySkin;
		
		// Make a background box
		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Sticker & crafter");

		GUI.Label (new Rect (Screen.width/2-50, Screen.height-130,180, 40), "Score du joueur 1");
		GUI.Label (new Rect (Screen.width/2-50, Screen.height-100, 180, 40), ""+GameState.score1);

		GUI.Label (new Rect (Screen.width/2-50, Screen.height-230, 180, 40), "Score du joueur 2");
		GUI.Label (new Rect (Screen.width/2-50, Screen.height-200, 180, 40), ""+GameState.score2);
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2-_rightOffset,20+_offsetWithTitle,_btnWidth,_btnHeight), "Rejouer niveau 1")) {
			Application.LoadLevel("level1");
		}

		if(GUI.Button(new Rect(Screen.width/2-_rightOffset,20+_offsetWithTitle,_btnWidth,_btnHeight), "Rejouer niveau 2")) {
			Application.LoadLevel("level2");
		}
		
		
		// Make the forth button.
		if(GUI.Button(new Rect(Screen.width/2-_rightOffset,20+_offsetWithTitle+_heightOffset*3,_btnWidth,_btnHeight), "Quitter")) {
			Application.Quit();
		}
		
	}
}
