using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball3 : MonoBehaviour
{
	public GameObject ballPrefab;
	public GameObject pointAncor;

	public float minDistanse;
	public float maxDistanse;

	Vector3 pointTarget;

	// Use this for initialization
	void Start ()
	{
		moveBall ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	Vector3 ballDirection ()
	{
		float posX = Random.Range (minDistanse, maxDistanse);
		float posY = Random.Range (minDistanse, maxDistanse);
		float posZ = Random.Range (minDistanse, maxDistanse);
		return new Vector3 (posX, posY, posZ);
	}

	void moveBall ()
	{
		pointTarget = ballDirection ();
		iTween.MoveTo (gameObject, iTween.Hash (
			"position", pointTarget,
			"time", 2,
			"easetype", iTween.EaseType.linear,
			"oncomplete", "initBullets"
		));
	}

	void initBullets ()
	{
		int r = Random.Range (3, 10);
		for (int i = 0; i <= r; i++) {
			GameObject b = Instantiate (ballPrefab, pointTarget, Quaternion.identity, pointAncor.transform);
			iTween.MoveTo (b, iTween.Hash (
				"position", ballDirection (),
				"time", 4,
				"easetype", iTween.EaseType.linear,
				"oncomplete", "destroyBall",
				"oncompletetarget", gameObject,
				"oncompleteparams", b
			));
		}
		moveBall ();
	}

	void destroyBall (GameObject go)
	{
		Destroy (go, 0);
	}
}
