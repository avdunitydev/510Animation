﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMain : MonoBehaviour
{
	public RectTransform panel_IN;
	public RectTransform panel_UP;

	public enum IsRegistrationOk
	{
		login = 1,
		email = 1 << 1,
		pswd = 1 << 2,
		re_pswd = 1 << 3
	}

	InputField loginR, emailR, password1, password2, login, password;
	Button butReg;
	IsRegistrationOk isOk;

	void Start ()
	{
		loginR = GameObject.FindGameObjectWithTag ("loginR").GetComponent<InputField> ();
		emailR = GameObject.FindGameObjectWithTag ("emailR").GetComponent<InputField> ();
		password1 = GameObject.FindGameObjectWithTag ("password1").GetComponent<InputField> ();
		password2 = GameObject.FindGameObjectWithTag ("password2").GetComponent<InputField> ();
		login = GameObject.FindGameObjectWithTag ("login").GetComponent<InputField> ();
		password = GameObject.FindGameObjectWithTag ("password").GetComponent<InputField> ();
		butReg = GameObject.FindGameObjectWithTag ("butReg").GetComponent<Button> ();
		butReg.interactable = false;
	}

	public void EndEditLoginR ()
	{
		if (loginR.text.Length < 4) {
			Debug.LogError ("Логін повинен містити не менше 4 символів");
			isOk &= ~IsRegistrationOk.login;
			IsActivBtnSignUp ();
		} else {
			StartCoroutine (FindName (loginR.text));
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

	public void EndEditEmailR ()
	{        
		if (emailR.text.Length < 7 && !emailR.text.Contains ("@")) {
			Debug.LogError ("Перевірте правильність написання пошти");
			isOk &= ~IsRegistrationOk.email;
			IsActivBtnSignUp ();
		} else {
			StartCoroutine (FindEmail (emailR.text));
		}
	}

	IEnumerator FindEmail (string signInEmail)
	{
		Debug.Log ("start find user email ...");
		WWWForm form = new WWWForm ();
		form.AddField ("email", signInEmail);

		WWW www = new WWW ("http://localhost/test2.site/php/findEmail.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError ("Error: email !" + www.error);
			yield break;
		}
		print ("... result >> " + www.text);
		if (www.text.Length == 1) {
			if (Equals (www.text, "1")) {
				Debug.LogError ("Така пошта використовуєьться, виберіть іншу");
				isOk &= ~IsRegistrationOk.email;
			} else if (Equals (www.text, "0")) {
				Debug.Log ("User email OK !");
				isOk |= IsRegistrationOk.email;
			}
			IsActivBtnSignUp ();
		}
		yield return null;
	}

	public void EndEditPassWord1 ()
	{
		if (password1.text.Length < 6) {
			Debug.LogError ("Пароль повинен містити не менше 6 символів");
			isOk &= ~IsRegistrationOk.pswd;
		} else {
			isOk |= IsRegistrationOk.pswd;
		}
		IsActivBtnSignUp ();
	}

	public void EndEditPassWord2 ()
	{
		if (!Equals (password1.text, password2.text)) {
			Debug.LogError ("Повторний пароль не збігається");
			isOk &= ~IsRegistrationOk.re_pswd;
		} else {
			isOk |= IsRegistrationOk.re_pswd;
		}
		IsActivBtnSignUp ();
	}

	void IsActivBtnSignUp ()
	{
		if (isOk == (IsRegistrationOk.email | IsRegistrationOk.login |
		    IsRegistrationOk.pswd | IsRegistrationOk.re_pswd)) {
			butReg.interactable = true;
		} else {
			butReg.interactable = false;
		}
	}

	public void OnButtonSignUP ()
	{
		StartCoroutine (AddNewUser (loginR.text, emailR.text, password1.text));
	}

	IEnumerator AddNewUser (string name, string email, string password)
	{
		print ("Start add User to DB ...");
		WWWForm form = new WWWForm ();
		form.AddField ("name", name);
		form.AddField ("email", email);
		form.AddField ("password", password);

		WWW www = new WWW ("http://localhost/test2.site/php/SignUpUser.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("... adding COMPLEAT !!!" + www.text);
		ChangeSignPanel (panel_IN);
		ChangeSignPanel (panel_UP);
		yield return null;
	}

	public void OnButtonSignIN ()
	{
		if (login.text.Length < 4 || password.text.Length < 6) {
			Debug.LogError ("Перевірте правильність вводу логіна та пароля");
		} else {
			StartCoroutine (SignInUser (login.text, password.text));
		}
	}

	IEnumerator SignInUser (string name, string password)
	{
		Debug.Log ("start sign IN ...");
		WWWForm form = new WWWForm ();
		form.AddField ("name", name);
		form.AddField ("password", password);

		WWW www = new WWW ("http://localhost/test2.site/php/SignInUser.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			Debug.LogError ("Error: " + www.error);
			yield break;
		}
		print ("... result >> " + www.text);
		if (www.text.Length < 24) {
			Debug.Log ("Вхід виконано успішно");
			PlayerPrefs.SetInt ("user_id", int.Parse (www.text));
			SceneManager.LoadScene (1);
		} else {
			Debug.LogError ("Не вірний логін або пароль. Pleas try again !!!");
		}
		yield return null;
	}

	public void ChangeSignPanel (RectTransform panel)
	{
		panel.position = new Vector3 (panel.position.x, -1 * panel.position.y, panel.position.z);
	}
		
}