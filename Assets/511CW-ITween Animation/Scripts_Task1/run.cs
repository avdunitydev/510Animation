using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
	public GameObject cubeL;
	public GameObject cubeR;
	public float speed = 2f;

	// Use this for initialization
	void Start ()
	{
		moveCube ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance (cubeL.transform.position, transform.position) <= 2f) {
			moveBallUp ();
		}

	}

	void moveCube ()
	{
		iTween.MoveTo (cubeL, iTween.Hash (
			"x", -2f, 
			"time", speed, 
			"easetype", iTween.EaseType.linear, 
			"looptype", iTween.LoopType.pingPong));
		iTween.MoveTo (cubeR, iTween.Hash (
			"x", 2f, 
			"time", speed, 
			"easetype", iTween.EaseType.linear, 
			"looptype", iTween.LoopType.pingPong));
	}

	void moveBallUp ()
	{
		iTween.MoveTo (gameObject, iTween.Hash (
			"y", 13f, 
			"time", speed - 0.5f, 
			"easetype", iTween.EaseType.easeOutSine));
		iTween.MoveTo (gameObject, iTween.Hash (
			"y", 0.5f, 
			"easetype", iTween.EaseType.easeOutBounce, 
			"time", speed - 0.5f, 
			"delay", speed - 0.7f));
	}
}
