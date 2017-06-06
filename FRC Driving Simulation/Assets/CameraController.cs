using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	Quaternion targetRotation;

	public Vector3 targetRotationEuler;
	public Vector3 targetPosition;
	Vector3 startPosition;
	public float lerpTime;

	public bool followRobot = true;

	// Use this for initialization
	void Start () {

		targetRotation = Quaternion.Euler (targetRotationEuler);

		startPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		if(followRobot)
			transform.LookAt (target.position);

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (followRobot) {
				StartCoroutine (MoveAndRotateToPoint (transform, transform.position, targetPosition, transform.rotation, targetRotation, lerpTime, false));
				followRobot = false;

			} else {
				StartCoroutine(MoveAndRotateToPoint (transform, transform.position, startPosition, transform.rotation, Quaternion.LookRotation ((target.position - startPosition).normalized), lerpTime, true));

			}
		}
	}
	IEnumerator MoveAndRotateToPoint(Transform t, Vector3 startPos, Vector3 finalPos, Quaternion startRot, Quaternion finalRot, float time, bool setFollowRobotTrue){
		float i = 0f;
		float rate = 1f / time;

		while (i < 1) {

			i += Time.deltaTime * rate;
			transform.rotation = Quaternion.Lerp (startRot, finalRot, i);
			transform.position = Vector3.Lerp (startPos, finalPos, i);
			yield return null;
		}

		if (setFollowRobotTrue) {
			followRobot = true;
		}
	}
}
