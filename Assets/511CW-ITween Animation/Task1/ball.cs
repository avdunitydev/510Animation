using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
	public Transform cubeL;
	public Transform cubeR;
	public bool distCubeL = false;
	public bool distCubeR = false;


	// Use this for initialization
	void Start ()
	{
		//iTween.MoveTo ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (cubeL) {
			if (Vector3.Distance (cubeL.position, transform.position) <= 2) {
				distCubeL = true;
			} else {
				distCubeL = false;
			}
		}
		if (cubeR) {
			if (Vector3.Distance (cubeR.position, transform.position) <= 2) {
				distCubeR = true;
			} else {
				distCubeR = false;
			}
		}

	}
}
