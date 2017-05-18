using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	
	public Vector3 startMousePosition;
	float mDeltaDistance;
	public float mDeltaPosX;
	public float mDeltaPosY;
	public float mDeltaPosZ;

	private Quaternion m_CameraCurentLook;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		//----------------------------------------------------------v2
		if (Input.GetMouseButtonDown (1)) {
			m_CameraCurentLook = Camera.main.transform.localRotation;
		}
		/*if (Input.GetMouseButton (1)) {
			Camera.main.transform.rotation = Quaternion.Slerp (m_CameraCurentLook, 
				Quaternion.Euler (-Input.mousePosition.y, Input.mousePosition.x, Input.mousePosition.z),
				2f);
			m_CameraCurentLook = Camera.main.transform.rotation;
		}*/

		if (Input.GetMouseButton (1)) {
			Camera.main.transform.localRotation = Quaternion.Euler (
				-Input.mousePosition.y, 
				Input.mousePosition.x, 
				Input.mousePosition.z);
			m_CameraCurentLook = Camera.main.transform.localRotation;
		}

		if (Input.GetMouseButtonUp (1)) {
			Camera.main.transform.localRotation = m_CameraCurentLook;
		}


		/*if (Input.GetMouseButtonDown (1)) {
			startMousePosition = Input.mousePosition;
		}
         /*
		if (Input.GetMouseButton (1)) {
			transform.localRotation = Quaternion.Euler (
				Quaternion.identity.x + Input.mousePosition.y,
				Input.mousePosition.x,
				Input.mousePosition.z);
				
		}*/

		/*if (Input.GetMouseButtonDown (0)) {
			startMousePosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonDown (1)) {
			startMousePosition = Input.mousePosition;
		}

		if (Input.GetMouseButton (0)) {
			mDeltaDistance = (transform.position - startMousePosition).y * 0.03f;
			transform.localPosition = new Vector3 (
				transform.localPosition.x, 
				transform.localPosition.y,
				transform.position.z + mDeltaDistance);
		}

		if (Input.GetMouseButton (1)) {
			
			mDeltaPosX = ((Input.mousePosition - startMousePosition).x * 0.03f) / Time.deltaTime;
			Debug.Log ("mDeltaPosX = " + mDeltaPosX);
			mDeltaPosY = ((Input.mousePosition - startMousePosition).y * 0.03f) / Time.deltaTime;

			transform.localRotation = Quaternion.Euler (mDeltaPosY, -mDeltaPosX, 0f);
		
			startMousePosition = Input.mousePosition;
		}*/

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
		changeColor ();
	}

	void changeColor ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo, 750f)) {
			if (hitInfo.collider.tag == "cubePoint") {
				hitInfo.collider.GetComponent<MeshRenderer> ().material.color = new Color (
					Random.Range (0f, 250f),
					Random.Range (0f, 250f),
					Random.Range (0f, 250f));

				/*iTween.ColorTo (hitInfo.collider.gameObject, iTween.Hash (
					"r", Random.Range (0f, 250f),

					"time", 1f,
					"looptype", iTween.LoopType.pingPong
				));*/
			}
		}
	}
}

