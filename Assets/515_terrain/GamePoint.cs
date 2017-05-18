using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoint : MonoBehaviour
{
	public GameObject pointPerfab;

	// Use this for initialization
	void Start ()
	{
		initPoints ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	Vector3 pointPosition ()
	{
		float posX = transform.position.x + Random.Range (-100, 100);
		float posY = transform.position.y + 100f;
		float posZ = transform.position.z + Random.Range (-100, 100);
		return new Vector3 (posX, posY, posZ);
	}

	void initPoints ()
	{
		int r = Random.Range (10, 20);
		for (int i = 0; i <= r; i++) {
			GameObject b = Instantiate (pointPerfab, pointPosition (), Quaternion.identity, transform);
			iTween.RotateTo (b, iTween.Hash (
				"y", 360f,
				"z", 360f,
				"time", 4,
				"easetype", iTween.EaseType.linear,
				"looptype", iTween.LoopType.pingPong
			));
		}
	}

}
