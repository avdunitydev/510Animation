using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAndroid : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("Input.acceleration == " + Input.acceleration);
		//Debug.Log ("Input.accelerationEventCount == " + Input.accelerationEventCount);
		//Debug.Log ("Input.gyro.ToString () == " + Input.gyro.ToString ());
		//Debug.Log ("Input.compass.ToString () == " + Input.compass.ToString ());
		//Debug.Log ("Input.GetMouseButton (0).ToString () == " + Input.GetMouseButton (0).ToString ());
		//Debug.Log ("Input.deviceOrientation.ToString() == " + Input.deviceOrientation.ToString ());
		//Debug.Log ("Input.location.isEnabledByUser.ToString () == " + Input.location.isEnabledByUser.ToString ());
		Debug.Log ("Input.touchCount == " + Input.touchCount);
		Debug.Log ("Input.touchPressureSupported == " + Input.touchPressureSupported);
		Debug.Log ("Input.touchSupported == " + Input.touchSupported);
	}
}
