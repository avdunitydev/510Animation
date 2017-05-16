using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	
	public Vector3 startMousePosition;
	float mDeltaDistance;
	//Vector3 mTargetLookWorld;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		startMousePosition = Input.mousePosition;
		if (Input.GetMouseButton (0)) {
			mDeltaDistance = (transform.position - startMousePosition).y * 0.03f;
			transform.localPosition = new Vector3 (
				transform.localPosition.x, 
				transform.localPosition.y,
				transform.position.z + mDeltaDistance);
		}

		if (Input.GetMouseButton (1)) {
			float mDeltaPosX = (transform.position - startMousePosition).x * 0.3f;
			float mDeltaPosY = (transform.position - startMousePosition).y * 0.3f;
			transform.localRotation = Quaternion.Euler (mDeltaPosY, -mDeltaPosX, 0f);
			//transform.localRotation = Quaternion.Euler (mDeltaPosX, mDeltaPosY, 0f);
			//transform.LookAt (Input.mousePosition);
		}
		startMousePosition = Input.mousePosition;

		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			GameObject camL = GameObject.FindWithTag ("CameraLeft");
			camL.GetComponent<Camera> ().rect = new Rect (0f, 0f, 0.2f, 0.3f);
			GameObject camR = GameObject.FindWithTag ("CameraRight");
			camR.GetComponent<Camera> ().rect = new Rect (0.8f, 0f, 0.2f, 0.3f);
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			GameObject cam = GameObject.FindWithTag ("CameraLeft");
			cam.GetComponent<Camera> ().rect = new Rect (0f, 0f, 1f, 1f);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			GameObject cam = GameObject.FindWithTag ("CameraRight");
			cam.GetComponent<Camera> ().rect = new Rect (0f, 0f, 1f, 1f);
		}
	}
}
