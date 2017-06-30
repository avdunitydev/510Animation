using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInDB : MonoBehaviour
{
	public Button btnSIN;
	public Button btnSUP;
	public RectTransform alert;
	public Text textAlert;
	public Text consoleText;

	public enum IsValidate
	{
		login = 1,
		email = 1 << 1,
		pass = 1 << 2,
		rePass = 1 << 3
	}

	IsValidate isFieldOk;

	// Show Alert dialog
	void ShowAlert (RectTransform alertPanel, Text targetText, string alertText)
	{
		targetText.text = alertText;
		alertPanel.gameObject.SetActive (true);
	}
	
	// Validate field Name
	bool ValidateName (InputField targetField)
	{
		if (targetField.text.Length < 4) {
			ShowAlert (alert, textAlert, "Логін повинен містити не менше 4 символів");
			isFieldOk &= ~IsValidate.login;
			SINPanelActivBtn (btnSIN);
			return false;
		} else {
			SINPanelActivBtn (btnSIN);
			return true;
		}
		return false;
	}
	// Check name, email and interactable button
	public void SINPanelActivBtn (Button targetButton)
	{
		if (isFieldOk == (IsValidate.email | IsValidate.login)) {
			targetButton.interactable = true;
		} else {
			targetButton.interactable = false;
		}
	}

	// Check name in DB
	public void EndEditName_IN (InputField targetField)
	{
		if (ValidateName (targetField)) {
			StartCoroutine (FindName (targetField.text));
		}
	}

	IEnumerator FindName (string nameSIN)
	{
		Debug.Log ("start find user name ...");
		WWWForm form = new WWWForm ();
		form.AddField ("name", nameSIN);

		WWW www = new WWW ("http://localhost/www.local/php_wd/findName.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError ("Error: name !" + www.error);
			yield break;
		}
		Debug.Log ("... result >> " + www.text);
		if (www.text.Length == 1) {
			if (Equals (www.text, "1")) {
				Debug.LogError ("Такий логін зайнятий виберіть інший");
				isFieldOk &= ~IsValidate.login;
			} else if (Equals (www.text, "0")) {
				Debug.Log ("User name OK !");
				isFieldOk |= IsValidate.login;
			}
			SINPanelActivBtn (btnSIN);
		}
		yield return null;
	}

	// Check email in DB
	public void EndEditEmail_IN (InputField targetField)
	{        
		if (targetField.text.Length < 7 && !targetField.text.Contains ("@")) {
			ShowAlert (alert, textAlert, "Перевірте правильність написання пошти");
			//Debug.LogError ("Перевірте правильність написання пошти");
			isFieldOk &= ~IsValidate.email;
			SINPanelActivBtn (btnSIN);
		} else {
			StartCoroutine (FindEmail (targetField.text));
		}
	}

	IEnumerator FindEmail (string emailSIN)
	{
		Debug.Log ("start find user email ...");
		WWWForm form = new WWWForm ();
		form.AddField ("email", emailSIN);

		WWW www = new WWW ("http://localhost/www.local/php_wd/findEmail.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError ("Error: email !" + www.error);
			yield break;
		}
		print ("... result >> " + www.text);
		if (www.text.Length == 1) {
			if (Equals (www.text, "1")) {
				Debug.LogError ("Така пошта використовуєьться, виберіть іншу");
				isFieldOk &= ~IsValidate.email;
			} else if (Equals (www.text, "0")) {
				Debug.Log ("User email OK !");
				isFieldOk |= IsValidate.email;
			}
			SINPanelActivBtn (btnSIN);
		}
		yield return null;
	}

}
