using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterTrackerDGR : MonoBehaviour
{
	public static CharacterTrackerDGR instance;
	public Text TrackerText;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
			Talked();
		}
	}


	private int count = -1;
	private const int studentno = 7;
	private const string otext = "Students Talked To:{0}/{1}";

	public void Talked()
	{
		count++;
		string todisplay = string.Format(otext, count, studentno);
		TrackerText.text = todisplay;
		if (count == studentno)
		{
			SceneManager.LoadScene("Level4DanganTrial");
		}
	}
}
