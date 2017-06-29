using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleButton : MonoBehaviour
{
	float scale = 0.3f;

	public void ScaleUp (RectTransform targetButton)
	{
		targetButton.localScale += new Vector3 (scale, scale, 0f);
	}

	public void ScaleExit (RectTransform targetButton)
	{
		targetButton.localScale -= new Vector3 (scale, scale, 0f);
	}
}
