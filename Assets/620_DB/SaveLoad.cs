using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour
{
	public Transform[] objects;
	public MiniPlayer player;

	public void ExitScene ()
	{
		SceneManager.LoadScene (0);
	}

	public void SaveData ()
	{
		// 1-змінна    2-позиція     3-поворот
		string strSave = "";
		strSave += "1:hp:" + player.chrHP + ";";
		strSave += "1:speed:" + player.chrSpeed + ";";
		strSave += "1:user_id:" + player.userID + ";";
		strSave += "1:user_level:" + player.userLevel;

		for (int i = 0; i < objects.Length; ++i) {
			strSave += ";2:" + objects [i].name + ":" + objects [i].position.x + ":" + objects [i].position.y + ":" + objects [i].position.z;
			strSave += ";3:" + objects [i].name + ":" + objects [i].eulerAngles.x + ":" + objects [i].eulerAngles.y + ":" + objects [i].eulerAngles.z;
		}
		print ("Data to save\n" + strSave);

		StartCoroutine (SaveDataToDB (player.userID, strSave));
	}

	IEnumerator SaveDataToDB (int id_user, string data)
	{
		print ("Data saving ...");
		WWWForm form = new WWWForm ();
		form.AddField ("user_id", id_user);
		form.AddField ("data", data);

		WWW www = new WWW ("http://localhost/test2.site/php/UpdateData.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("... result >> " + www.text);
		yield return null;
	}

	public void LoadData ()
	{
		StartCoroutine (LoadDataFromDB (player.userID));
	}

	IEnumerator LoadDataFromDB (int user_id)
	{
		print ("Data loading ...");
		WWWForm form = new WWWForm ();
		form.AddField ("user_id", user_id);

		WWW www = new WWW ("http://localhost/test2.site/php/SelectData.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("... result >> " + www.text);

		string[] temp = www.text.Split (';');
		for (int i = 0; i < temp.Length; ++i) {
			string[] temp1 = temp [i].Split (':');
			switch (temp1 [0]) {
			case "1":
				{
					if (temp1 [1] == "hp") {
						player.chrHP = float.Parse (temp1 [2]);
					} else if (temp1 [1] == "speed") {
						player.chrSpeed = float.Parse (temp1 [2]);
					} else if (temp1 [1] == "money") {
						player.userLevel = int.Parse (temp1 [2]);
					}
					break;
				}
			case "2":
				{
					for (int j = 0; j < objects.Length; ++j) {
						if (string.Equals (objects [j].name, temp1 [1])) {
							objects [j].position = new Vector3 (float.Parse (temp1 [2]), float.Parse (temp1 [3]), float.Parse (temp1 [4]));
							break;
						}
					}
					break;
				}
			case "3":
				{
					for (int j = 0; j < objects.Length; ++j) {
						if (string.Equals (objects [j].name, temp1 [1])) {
							objects [j].eulerAngles = new Vector3 (float.Parse (temp1 [2]), float.Parse (temp1 [3]), float.Parse (temp1 [4]));
							break;
						}
					}
					break;
				}
			}
		}

		yield return null;
	}

}
