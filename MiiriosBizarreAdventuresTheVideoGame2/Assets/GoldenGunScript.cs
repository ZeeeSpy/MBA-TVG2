using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenGunScript : MonoBehaviour
{
	public static GoldenGunScript Instance;
	private Text UIText;
	private int count = -1;
	private const string template = "Optional \n• {0}/4 Golden gun parts found";

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
			UIText = GetComponent<Text>();
			PlayerPrefs.SetInt("Gun", 0);
			GetPart();
		}
	}

	public void GetPart()
	{
		count++;

		if (count != 4)
		{
			string textout = string.Format(template, count);
			UIText.text = textout;
		} else
		{
			UIText.text = "Optional \n•All parts found, Golden Intervention Unlocked";
			PlayerPrefs.SetInt("Gun", 1);
		}
	}
}
