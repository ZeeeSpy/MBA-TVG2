using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1ObjectivesScript : MonoBehaviour
{
	public static Level1ObjectivesScript Instance;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	public Text objectives;
	public Text oobjectives;

	private string[] objectivearr = new string[] {
		"Check Voicemails",
		"Check PS4",
		"Check Post",
		"Eat Some Protein",};


	public void UpdateObjectives(int inc)
	{
		objectivearr[inc] = "";
		string oout = "Objectives: \n";

		foreach (string o in objectivearr)
		{
			if (o != "")
			{
				oout = oout + "\n• " + o;
			}

		}

		objectives.text = oout;
	}
}
