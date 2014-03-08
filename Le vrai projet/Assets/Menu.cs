using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUISkin displaySkin;

	private float 	_btnWidth = 75,
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
		GUI.Box(new Rect(0,0,Screen.width,Screen.height), "Platform Crafting Simulator 2014");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(Screen.width/2-_rightOffset,20+_offsetWithTitle,_btnWidth,_btnHeight), "Jouer")) {
			Application.LoadLevel(1);
		}


			// Make the forth button.
		if(GUI.Button(new Rect(Screen.width/2-_rightOffset,20+_offsetWithTitle+_heightOffset*3,_btnWidth,_btnHeight), "Quitter")) {
				Application.Quit();
			}

	}
}
