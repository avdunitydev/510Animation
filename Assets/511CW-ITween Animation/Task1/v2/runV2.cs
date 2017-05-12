using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runV2 : MonoBehaviour
{
	public GameObject cubeL;
	public GameObject cubeR;
	public float speed = 2f;

	Vector3 startPosCubeL;
	Vector3 startPosCubeR;
	Vector3 startBallPos;

	// Use this for initialization
	void Start ()
	{
		startBallPos = transform.position;
		startPosCubeL = cubeL.transform.position;
		startPosCubeR = cubeR.transform.position;
		moveCubesIn ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*if (Vector3.Distance (cubeL.transform.position, transform.position) <= 2f) {
			moveBallUp ();
		}*/

	}

	void moveCubesIn ()
	{
		iTween.MoveTo (cubeL, iTween.Hash (
			"x", -2f, 
			"time", speed, 
			"easetype", iTween.EaseType.linear
		));
		iTween.MoveTo (cubeR, iTween.Hash (
			"x", 2f, 
			"time", speed, 
			"easetype", iTween.EaseType.linear,
			"oncompletetarget", gameObject,
			"oncomplete", "moveCubesOut"
		));
	}

	void moveCubesOut ()
	{
		iTween.MoveTo (cubeL, iTween.Hash (
			"position", startPosCubeL,
			"time", speed,
			"easetype", iTween.EaseType.linear, 
			"onstarttarget", gameObject,
			"onstart", "moveBallUp"
		));
		iTween.MoveTo (cubeR, iTween.Hash (
			"position", startPosCubeR,
			"time", speed,
			"easetype", iTween.EaseType.linear, 
			"oncompletetarget", gameObject,
			"oncomplete", "moveCubesIn"
		));
	}

	void moveBallUp ()
	{
		iTween.MoveTo (gameObject, iTween.Hash (
			"y", 13f, 
			"time", speed - 0.5f, 
			"easetype", iTween.EaseType.easeOutSine,
			"oncomplete", "moveBallDown"
		));
	}

	void moveBallDown ()
	{
		iTween.MoveTo (gameObject, iTween.Hash (
			"position", startBallPos,
			"easetype", iTween.EaseType.easeOutBounce, 
			"time", speed - 0.5f
		));
		
	}
}
