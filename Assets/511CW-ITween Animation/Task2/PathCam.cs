using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCam : MonoBehaviour
{
	public Transform centre;
	public Transform[] pathCircle;
	public Transform[] objects;
	public float distToTarget;
	public float minDist;

	public bool run = true;
	public Vector3 targetLook;

	// Use this for initialization
	void Start ()
	{
		targetLook = centre.position;
		distToTarget = Vector3.Distance (targetLook, transform.position);	
		minDist = Vector3.Distance (targetLook, transform.position);	
		if (run) {
			cameraRun ();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (distToTarget == minDist) {
			for (int i = 0; i < objects.Length; ++i) {
				if (distToTarget > Vector3.Distance (objects [i].position, transform.position)) {
					minDist = Vector3.Distance (objects [i].position, transform.position);
					targetLook = objects [i].position;
					iTween.LookUpdate (gameObject, iTween.Hash (
					));
				}
			}
		}*/

	}

	void cameraRun ()
	{
		iTween.MoveTo (gameObject, iTween.Hash (
			"path", pathCircle, 
			"looktarget", targetLook, 
			"looktime", 0.1f,
			"time", 24,
			"easetype", iTween.EaseType.linear, 
			"looptype", iTween.LoopType.pingPong,
			"onupdate", "checkDist"
		));

	}

	public void checkDist ()
	{
		
	}


}
