using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

	public float travelTime = 1f;
	public Vector3[] nodes;

	Rigidbody r;

	Vector3 startEuler;

	int lastNode = 0;
	int currentNode = 1;

	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();

		startEuler = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (nodes.Length > 0) {
			if (lastNode != currentNode) {
				StartCoroutine (MoveAndRotateToPoint (transform, transform.position, nodes [currentNode], transform.eulerAngles, startEuler, travelTime));
				lastNode = currentNode;
			}
		} else {
			r.velocity = Vector3.zero;
		}
		
	}

	IEnumerator MoveAndRotateToPoint(Transform t, Vector3 startPos, Vector3 finalPos, Vector3 startRot, Vector3 finalRot, float time){
		float i = 0f;
		float rate = 1f / time;

		while (i < 1) {

			i += Time.deltaTime * rate;

			//transform.rotation = Quaternion.Lerp (startRot, finalRot, i);
			//transform.position = Vector3.Lerp (startPos, finalPos, i);

			//r.MovePosition (Vector3.Lerp (startPos, finalPos, i));
			//r.MoveRotation(Quaternion.Lerp (startRot, finalRot, i));

			r.velocity = (finalPos - startPos)/ time;
			r.angularVelocity = (finalRot - startRot) / time;


			yield return new WaitForFixedUpdate();
		}

		currentNode++;

		if (currentNode >= nodes.Length) {
			currentNode = 0;
		}
			
	}
}
