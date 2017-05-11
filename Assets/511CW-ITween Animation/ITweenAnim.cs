using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITweenAnim : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		iTween.MoveTo (gameObject, iTween.Hash ("position", new Vector3 (10, 10, 10), 
			"time", 8, "delay", 2, "easetype", iTween.EaseType.easeOutElastic, "looptype", 
			iTween.LoopType.pingPong));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
