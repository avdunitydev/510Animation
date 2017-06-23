using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPlayer : MonoBehaviour
{
	public float chrHP;
	public float chrSpeed;
	public int userID;
	public int userLevel;

	void Start ()
	{
		userID = PlayerPrefs.GetInt ("user_id", 0);
	}
}
