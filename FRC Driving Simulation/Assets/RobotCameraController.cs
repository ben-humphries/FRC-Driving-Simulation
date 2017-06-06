using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCameraController : MonoBehaviour {

	Transform robot;

	public Camera mainCamera;

	CameraController camController;

	Quaternion targetRotation;
	public Vector3 targetRotationEuler;
	public float lerpTime = 0.5f;


	// Use this for initialization
	void Start () {

		camController = mainCamera.GetComponent<CameraController> ();
		robot = transform.GetComponentInParent<Transform> ();

		targetRotation = Quaternion.Euler (targetRotationEuler);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (camController.followRobot) {
				StartCoroutine (RotateToPoint (camController.transform, camController.transform.rotation, targetRotation, lerpTime, false));
				camController.followRobot = false;

			} else {
				StartCoroutine(RotateToPoint (camController.transform, camController.transform.rotation, Quaternion.LookRotation ((robot.position - camController.transform.position).normalized), lerpTime, true));

			}
		}
		
	}

	IEnumerator RotateToPoint(Transform t, Quaternion startRot, Quaternion finalRot, float time, bool setFollowRobotTrue){
		float i = 0f;
		float rate = 1f / time;

		while (i < 1) {
			
			i += Time.deltaTime * rate;
			camController.transform.rotation = Quaternion.Lerp (startRot, finalRot, i);
			yield return null;
		}

		if (setFollowRobotTrue) {
			camController.followRobot = true;
		}
	}
}
