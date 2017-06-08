using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Canvas pauseMenuCanvas;

	public ChassisController chassisController;

	bool pauseMenuEnabled = false;

	// Use this for initialization
	void Start () {
		pauseMenuEnabled = false;

		pauseMenuCanvas.gameObject.SetActive (pauseMenuEnabled);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && !chassisController.finished) {
			pauseMenuEnabled = !pauseMenuEnabled;
			pauseMenuCanvas.gameObject.SetActive (pauseMenuEnabled);


			chassisController.paused = !chassisController.paused;
		}

		if (chassisController.paused) {
			UpdateConnectedJoysticks ();
		}
	}
	public void UpdateConnectedJoysticks(){
		Text t = pauseMenuCanvas.transform.GetChild (2).GetComponent<Text>();

		string[] joystickNames = Input.GetJoystickNames();

		string rightJoystick = "No joystick connected.";
		string leftJoystick = "No joystick connected.";

		if (joystickNames.Length == 1) {

			rightJoystick = joystickNames [0] != null && joystickNames [0].Length > 0 ? joystickNames [0] : "No joystick connected.";
		} else if(joystickNames.Length == 2){

			rightJoystick = joystickNames [0] != null && joystickNames [0].Length > 0 ? joystickNames [0] : "No joystick connected.";
			leftJoystick = joystickNames [1] != null && joystickNames [1].Length > 0 ? joystickNames [1] : "No joystick connected.";

		}


		t.text = "Right Joystick: " + rightJoystick + "\n" +
				 "Left Joystick: " + leftJoystick;
	}
}
