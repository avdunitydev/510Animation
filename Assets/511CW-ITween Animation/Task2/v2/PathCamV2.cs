using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCamV2 : MonoBehaviour
{
	public Transform centre;
	public Transform[] pathCircle;
	public Transform[] objects;
	public bool run = true;

	public Vector3 pointToLook;
	public Vector3 pointToNextMove;
	public float distToTarget;
	public float moveSpeed;

	public float distance;
	int n;

	// Use this for initialization
	void Start ()
	{
		n = 0;
		pointToLook = centre.position;
		distToTarget = Vector3.Distance (pointToLook, transform.position);
		getMovePoint ();

		if (run) {
			cameraRun ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void runMove ()
	{
	}

	void getMovePoint ()
	{
		pointToNextMove = pathCircle [n].position;
		if (n == pathCircle.Length - 1) {
			n = 0;
		} else {
			n++;
		}
	}

	void nextPoint ()
	{
		getMovePoint ();
		cameraRun ();
	}


	void cameraRun ()
	{
		iTween.MoveTo (gameObject, iTween.Hash (
			"position", pointToNextMove,
			"looktarget", pointToLook, 
			"looktime", 0.333f,
			"time", moveSpeed,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "nextPoint"
		));







		/*for (int i = 0; i < pathCircle.Length; i++) {
			Vector3 nextPoint = pathCircle [i].position;
			if (Vector3.Distance (nextPoint, transform.position) >= 0.01f) {
				runMove ();
				++i;
			}
			
		}*/

	}

	void checkDist ()
	{
		Transform targetObj = centre;
		//minDist = Vector3.Distance (pointToLook, transform.position);
		//distToTarget = Vector3.Distance (pointToLook, transform.position);

		for (int i = 0; i < objects.Length; i++) {
			if (distToTarget > Vector3.Distance (objects [i].position, transform.position)) {
				//minDist = Vector3.Distance (objects [i].position, transform.position);
				targetObj = objects [i];
			}
		}

		pointToLook = targetObj.position;

		lookToTarget ();
	}

	void lookToTarget ()
	{
		//checkDist ();
		iTween.LookTo (gameObject, pointToLook, 0.1f);		
	}
}
