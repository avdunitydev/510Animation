using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeL : MonoBehaviour
{
	public Transform lookTarget;
	public bool run = false;
	public float speed = 1f;

	// Use this for initialization
	void Start ()
	{
		if (run) {
			
			iTween.MoveTo (gameObject, iTween.Hash ("x", -2f, "time", speed,
				"easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong));
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnMoseDown ()
	{
		
	}
}
