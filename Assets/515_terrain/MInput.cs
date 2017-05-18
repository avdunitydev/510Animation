using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MInput : MonoBehaviour
{
	public GameObject[] somePerfabs;

	public string str;
	public float deltaTime;

	// Use this for initialization
	void Start ()
	{
		str = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		deltaTime = Time.deltaTime;
		if (Input.GetMouseButton (0)) {
			growUp ();
		}
		if (Input.GetMouseButton (1)) {
			growDown ();
		}

		checkInputText ();

	}

	void initGO (string name)
	{
		foreach (var v in somePerfabs) {
			if (v.name.Equals (name)) {
				GameObject tempGO = Instantiate (v, initRundomPosition (), Quaternion.identity, transform);
			}
		}
	}

	Vector3 initRundomPosition ()
	{
		return new Vector3 (
			transform.position.x + Random.Range (-10, 10), 
			50f, 
			transform.position.z + Random.Range (-10, 10)
		);
	}

	void checkInputText ()
	{
		if (str != "") {
			if (str.Equals ("mSphere")) {
				initGO (str);
				str = "";
			} else if (str == "Cube") {
				initGO (str);
				str = "";
			} else if (str == "Bullet") {
				initGO (str);
				str = "";
			} else if (str == "Colone") {
				initGO (str);
				str = "";
			} else if (str.Length > 8) {
				str = "";
			}
		}

		foreach (char c in Input.inputString) {
			if (c == "\n" [0] || c == "\r" [0]) {
				print ("User entered their name: " + str);
				str = "";
			} else {
				str += c;
			}
		}

	}

	void growUp ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo, 750f)) {
			if (hitInfo.collider.tag.Equals ("cubePoint") || hitInfo.collider.tag.Equals ("bullet")) {
				hitInfo.transform.localScale += new Vector3 (1f * Time.deltaTime, 1f * Time.deltaTime, 1f * Time.deltaTime);

				/*hitInfo.collider.GetComponent<MeshRenderer> ().material.color = new Color (
					Random.Range (0f, 250f),
					Random.Range (0f, 250f),
					Random.Range (0f, 250f));

				/*iTween.ColorTo (hitInfo.collider.gameObject, iTween.Hash (
					"r", Random.Range (0f, 250f),

					"time", 1f,
					"looptype", iTween.LoopType.pingPong
				));*/
			}
		}
	}

	void growDown ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo, 750f)) {
			if (hitInfo.collider.tag.Equals ("cubePoint") || hitInfo.collider.tag.Equals ("bullet")) {
				hitInfo.transform.localScale += new Vector3 (-1f * Time.deltaTime, -1f * Time.deltaTime, -1f * Time.deltaTime);

			}
		}
	}

}
