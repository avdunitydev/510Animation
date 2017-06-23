using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPosition : MonoBehaviour
{

	public Transform targetObject;
	private IEnumerator startSendingToDB;
	WWWForm tempForm;

	// Use this for initialization
	void Start ()
	{
		//startSendingToDB = SendPosition (targetObject.position);
		//StartCoroutine (startSendingToDB);
		tempForm = new WWWForm ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			
		}
	}
	/*
	private IEnumerator SendPosition (Vector3 position){
		Debug.Log("Start sending .......................");

		tempForm.AddField ("player_name", name);
		tempForm.AddField ("player_email", position.x.ToString);
		tempForm.AddField ("player_pass", position.y.ToString);
		tempForm.AddField ("player_gender", position.z.ToString);

		WWW www = new WWW ("http://www.local/php.resourses/send_go_position.php", tempForm);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.Log ("Error: " + www.error);
			yield break;
		}
		Debug.Log (">>>>> sending COMPLEAT" + www.text);
		yield return null;
	}*/
}
