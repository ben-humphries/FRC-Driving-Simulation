using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateVelocities(float linearVelocity, float angularVelocity){
		Text t = transform.GetChild (0).GetComponent<Text> ();

		t.text = "Linear Velocity: " + linearVelocity + " u/s" + "\n" +
				 "Angular Velocity: " + angularVelocity + " rad/s";
	}
	public void UpdateDriveMode(string driveMode){
		Text t = transform.GetChild (1).GetComponent<Text> ();

		t.text = "Drive Mode: " + driveMode;
	}
	public void UpdateTimer(float time){
		Text t = transform.GetChild (2).GetComponent<Text> ();

		t.text = "Time: " + time + "s";
	}

}
