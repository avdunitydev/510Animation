using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInDB : MonoBehaviour
{

	public void EndEditName_IN (InputField targetField)
	{
		if (targetField.text.Length < 4) {
			Debug.LogError ("Логін повинен містити не менше 4 символів");
			isOk &= ~IsRegistrationOk.login;
			IsActivBtnSignUp ();
		} else {
			StartCoroutine (FindName (targetField.text));
		}
	}

	IEnumerator FindName (string signInName)
	{
		Debug.Log ("start find user name ...");
		WWWForm form = new WWWForm ();
		form.AddField ("name", signInName);

		WWW www = new WWW ("http://localhost/test2.site/php/findName.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError ("Error: name !" + www.error);
			yield break;
		}
		Debug.Log ("... result >> " + www.text);
		if (www.text.Length == 1) {
			if (Equals (www.text, "1")) {
				Debug.LogError ("Такий логін зайнятий виберіть інший");
				isOk &= ~IsRegistrationOk.login;
			} else if (Equals (www.text, "0")) {
				Debug.Log ("User name OK !");
				isOk |= IsRegistrationOk.login;
			}
			IsActivBtnSignUp ();
		}
		yield return null;
	}
}
