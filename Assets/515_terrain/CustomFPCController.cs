using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFPCController : MonoBehaviour
{

	public float moveSpeed = 2f;
	public float sensetiveSpeed = 1.2f;
	public LayerMask mLayerMask;
	public Transform gun;
	public Rigidbody bullet;
	public float fireDelta = 0.2F;

	Rigidbody character;
	Transform cam;
	Vector3 rotCam;
	private float nextFire = 0.5F;
	private float myTime = 0.0F;
	private bool isMove = true;

	void Start ()
	{
		character = GetComponent<Rigidbody> ();
		cam = Camera.main.transform;
	}

	void Update ()
	{
		myTime += Time.deltaTime;
		//moveCharacter ();
		//moveLook ();

		if (isMove) {
			moveCharacter_v2 ();
		}
		if (!isMove) {
			moveLook_v2 ();
		}


		if (Input.GetKeyDown (KeyCode.Space) && Physics.OverlapSphere (transform.position - new Vector3 (0, 1f, 0), 0.5f, mLayerMask).Length > 0) {
			character.AddForce (0, 300, 0);
		}

		/*if (Input.GetMouseButtonDown (0)) {
			Rigidbody temp = Instantiate (bullet, gun.position, Quaternion.identity);
			temp.AddForce (gun.transform.TransformDirection (new Vector3 (0, 0, 3000)));
		}*/

		if (Input.GetMouseButton (0) && myTime > nextFire) {
			nextFire = myTime + fireDelta;
			Rigidbody temp = Instantiate (bullet, gun.position, Quaternion.identity);
			temp.AddForce (gun.transform.TransformDirection (new Vector3 (0, 0, 3000)));
			nextFire -= myTime;
			myTime = 0.0F;
		}

		if (Input.GetMouseButton (1) && isMove) {
			isMove = !isMove;
		}

		if (Input.GetMouseButtonUp (1) && !isMove) {
			isMove = !isMove;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Cursor.visible = !Cursor.visible;
			if (Cursor.visible) {
				Cursor.lockState = CursorLockMode.None;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
			}
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			moveSpeed = 6f;
		}
		if (Input.GetKey (KeyCode.LeftControl)) {
			moveSpeed = 0.5f;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) || Input.GetKeyUp (KeyCode.LeftControl)) {
			moveSpeed = 2f;
		}

	}

	void moveLook ()
	{
		if (cam.localEulerAngles.x > 310f && cam.localEulerAngles.x < 360f ||
		    (cam.localEulerAngles.x < 25f && cam.localEulerAngles.x > 0f)) {
		} else {
			cam.localEulerAngles = rotCam;
		}

		transform.Rotate (0, Input.GetAxis ("Mouse X") * sensetiveSpeed, 0, Space.World);
		rotCam = cam.localEulerAngles;
		cam.Rotate (-Input.GetAxis ("Mouse Y") * sensetiveSpeed, 0, 0, Space.Self);
	}

	void moveLook_v2 ()
	{
		if (cam.localEulerAngles.x > 310f && cam.localEulerAngles.x < 360f ||
		    (cam.localEulerAngles.x < 25f && cam.localEulerAngles.x > 0f)) {
		} else {
			cam.localEulerAngles = rotCam;
		}

		transform.Rotate (0, Input.GetAxis ("mMouseX"), 0, Space.World);
		cam.Rotate (-Input.GetAxis ("mMouseY"), 0, 0, Space.Self);
		rotCam = cam.localEulerAngles;
	}

	void moveCharacter ()
	{
		character.velocity = transform.TransformDirection (
			Input.GetAxis ("Horizontal") * moveSpeed, 
			character.velocity.y,
			Input.GetAxis ("Vertical") * moveSpeed
		);
	}

	void moveCharacter_v2 ()
	{
		character.velocity = transform.TransformDirection (
			Input.GetAxis ("mMouseX") * moveSpeed, 
			character.velocity.y,
			Input.GetAxis ("mMouseY") * moveSpeed
		);
	}
}
