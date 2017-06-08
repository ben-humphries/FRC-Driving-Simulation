using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsCanvas : MonoBehaviour {

	public Settings settings;

	Toggle SquaredMovement;
	Slider RobotSpeed;
	Dropdown DefaultDriveMode;

	// Use this for initialization
	void Start () {

		SquaredMovement = transform.GetChild (1).GetComponent<Toggle> ();
		RobotSpeed = transform.GetChild (2).GetComponent<Slider> ();
		DefaultDriveMode = transform.GetChild (3).GetComponent<Dropdown> ();

		if (PlayerPrefs.GetInt ("FirstLoad") == 0) {
			ResetToDefaultValues ();
		}

		UpdateUIValues ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void UpdateSquaredMovement(bool squaredMovement){

		PlayerPrefs.SetInt ("SquaredMovement", squaredMovement ? 1 : 0);
	}
	public void UpdateRobotSpeed(){
		float robotSpeed = RobotSpeed.value;

		PlayerPrefs.SetFloat ("RobotSpeed", robotSpeed);
	}
	public void UpdateDefaultDriveMode(){
		int driveMode = DefaultDriveMode.value;

		PlayerPrefs.SetString ("DefaultDriveMode", driveMode == 0 ? "Tank" : "Mecanum");
	}
	public void ResetToDefaultValues(){

		PlayerPrefs.SetInt ("SquaredMovement", settings.DEFAULT_SQUARED_MOVEMENT);
		PlayerPrefs.SetFloat ("RobotSpeed", settings.DEFAULT_ROBOT_SPEED);
		PlayerPrefs.SetString ("DefaultDriveMode", settings.DEFAULT_DEFAULT_DRIVE_MODE);

		UpdateUIValues ();

	}
	public void UpdateUIValues(){
		
		SquaredMovement.isOn = PlayerPrefs.GetInt ("SquaredMovement") == 1 ? true : false;
		RobotSpeed.value = PlayerPrefs.GetFloat ("RobotSpeed");
		DefaultDriveMode.value = PlayerPrefs.GetString ("DefaultDriveMode").Equals ("Tank") ? 0 : 1;

	}
}
