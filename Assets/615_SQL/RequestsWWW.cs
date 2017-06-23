using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestsWWW : MonoBehaviour
{

	void Start ()
	{       
		StartCoroutine (AddUserToDB ("Elf 80 lv", "elf@gmail.com", "777", 1));
		//StartCoroutine (ShowAllPlayers ());
		//StartCoroutine(UpdateLevelScore(2, 100, 23156));
	}

	IEnumerator AddUserToDB (string name, string email, string password, int gender)
	{
		print ("start adding to DB");
		WWWForm form = new WWWForm ();

		form.AddField ("player_name", name);
		form.AddField ("player_email", email);
		form.AddField ("player_pass", password);
		form.AddField ("player_gender", gender);

		WWW www = new WWW ("http://www.local/php.resourses/add_user.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("compleat addind to db " + www.text);
		yield return null;
	}

	IEnumerator ShowAllPlayers ()
	{
		print ("start request to DB.players");

		WWW www = new WWW ("http://www.local/php.resourses/show_db_users.php");
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("fnish request to DB.players ");

		JSONObject jo = new JSONObject (www.text);

		foreach (var json in jo.list) {
			var data = json.ToDictionary ();
			print (
				data ["player_name"] + " " +
				data ["player_email"] + " " +
				data ["player_gender"] + " " +
				data ["player_hp"] + " " +
				data ["player_level"] + " " +
				data ["player_score"]
			);
		}
		yield return null;
	}

	IEnumerator UpdateLevelScore (int id, int level, int score)
	{
		print ("start uwp");
		WWWForm form = new WWWForm ();
		form.AddField ("id", id);
		form.AddField ("level", level);
		form.AddField ("score", score);
		WWW www = new WWW ("http://testdb/update_level_and_score.php", form);
		yield return www;

		if (!string.IsNullOrEmpty (www.error)) {
			print ("Error: " + www.error);
			yield break;
		}
		print ("fnish up " + www.text);

		yield return null;
	}

}
