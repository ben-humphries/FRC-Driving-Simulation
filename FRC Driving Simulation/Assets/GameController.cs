using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Canvas pauseMenuCanvas;

	public ChassisController chassisController;

	// Use this for initialization
	void Start () {
		pauseMenuCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			pauseMenuCanvas.enabled = !pauseMenuCanvas.enabled;

			chassisController.paused = !chassisController.paused;
		}

		if (chassisController.paused) {
			UpdateConnectedJoysticks ();
		}
	}
	public void UpdateConnectedJoysticks(){
		Text t = pauseMenuCanvas.transform.GetChild (2).GetComponent<Text>();

		string[] joystickNames = Input.GetJoystickNames();

		print ("aa" + joystickNames [1] + "aa");

		string rightJoystick = joystickNames [0] != null && joystickNames[0].Length > 0 ? joystickNames [0] : "No joystick connected.";
		string leftJoystick  = joystickNames [1] != null && joystickNames[1].Length > 0 ? joystickNames [1] : "No joystick connected.";

		t.text = "Right Joystick: " + rightJoystick + "\n" +
				 "Left Joystick: " + leftJoystick;
	}
}
