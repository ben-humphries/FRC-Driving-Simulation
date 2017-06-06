using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChassisController : MonoBehaviour {

	public UIController uiController;

	public Canvas PauseCanvas;

	public float speedLinear = 10f;
	public float speedAngular = 100f;
	public float joyDeadZone = 0.5f;

	public float rotationOffset = 3f;

	public bool squaredMovement = false;

	public DriveModes driveMode = DriveModes.Tank;

	[HideInInspector]
	public bool paused = false;


	private Rigidbody rigidbody;

	Vector3 lastLinearPosition;
	float lastAngularPosition;


	void Start () {

		rigidbody = GetComponent<Rigidbody> ();

		lastLinearPosition = Vector3.zero;
		lastAngularPosition = 0f;
		
	}
	
	void FixedUpdate () {

		if (!paused) {

			/*
		 * INPUT
		 */

			if (driveMode == DriveModes.Tank) {

				if (Mathf.Abs (Input.GetAxis ("VerticalLeft")) > joyDeadZone) {


					Vector3 rotatePoint = transform.position + transform.TransformDirection (Vector3.right) * rotationOffset;
					Vector3 rotateAxis = transform.TransformDirection (Vector3.up);

					Debug.DrawRay (rotatePoint, rotateAxis);

					transform.RotateAround (rotatePoint, rotateAxis, -speedAngular * Input.GetAxis ("VerticalLeft") * Time.fixedDeltaTime * (squaredMovement ? Mathf.Abs (Input.GetAxis ("VerticalLeft")) : 1));

				}
				if (Mathf.Abs (Input.GetAxis ("VerticalRight")) > joyDeadZone) {
					Vector3 rotatePoint = transform.position + transform.TransformDirection (Vector3.left) * rotationOffset;
					Vector3 rotateAxis = transform.TransformDirection (Vector3.up);

					Debug.DrawRay (rotatePoint, rotateAxis);

					transform.RotateAround (rotatePoint, rotateAxis, speedAngular * Input.GetAxis ("VerticalRight") * Time.fixedDeltaTime * (squaredMovement ? Mathf.Abs (Input.GetAxis ("VerticalRight")) : 1));

				}
			} else if (driveMode == DriveModes.Mecanum) {
			

				if (Mathf.Abs (Input.GetAxis ("VerticalRight")) > joyDeadZone) {
					transform.Translate (Vector3.forward * -speedLinear * Input.GetAxis ("VerticalRight") * Time.fixedDeltaTime * (squaredMovement ? Mathf.Abs (Input.GetAxis ("VerticalRight")) : 1));
				}

				if (Mathf.Abs (Input.GetAxis ("HorizontalRight")) > joyDeadZone) {
					transform.Translate (Vector3.right * speedLinear / 5f * Input.GetAxis ("HorizontalRight") * Time.fixedDeltaTime * (squaredMovement ? Mathf.Abs (Input.GetAxis ("HorizontalRight")) : 1));
				}

				if (Mathf.Abs (Input.GetAxis ("TwistRight")) > joyDeadZone) {
					transform.Rotate (0, speedAngular * Input.GetAxis ("TwistRight") * Time.fixedDeltaTime * (squaredMovement ? Mathf.Abs (Input.GetAxis ("TwistRight")) : 1), 0);

				}

			}

			float linearVelocity = Mathf.Round (((transform.position - lastLinearPosition) / Time.fixedDeltaTime).magnitude * 100f) / 100f;
			lastLinearPosition = transform.position;

			float angularVelocity = Mathf.Round ((transform.eulerAngles.y - lastAngularPosition) / Time.fixedDeltaTime * Mathf.Deg2Rad  * 100f) / 100f;
			lastAngularPosition = transform.eulerAngles.y;

			uiController.UpdateVelocities (linearVelocity, angularVelocity);


		}
	}

	void OnCollisionExit(Collision col){
		
		rigidbody.isKinematic = true;

		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		rigidbody.isKinematic = false;

	}
	public enum DriveModes{
		Tank,
		Mecanum
	}

	public void setDriveMode(){

		int index = PauseCanvas.transform.GetChild (1).GetComponent<Dropdown> ().value;

		if (index == 0) {
			driveMode = DriveModes.Tank;
		} else if (index == 1) {
			driveMode = DriveModes.Mecanum;
		}

		uiController.UpdateDriveMode (index == 0 ? "Tank" : "Mecanum");
	}


}
