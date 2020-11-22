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
	public BoxCollider Door;

	private string[] objectivearr = new string[] {
		"Check Voicemails",
		"Check PS4",
		"Check Post",
		"Eat Some Protein",};


	public void UpdateObjectives(int inc)
	{
		objectivearr[inc] = "";
		string oout = "Objectives: \n";
		int temp = 0;

		foreach (string o in objectivearr)
		{
			if (o != "")
			{
				oout = oout + "\n• " + o;
			} else
			{
				
				temp++;
			}

		}

		objectives.text = oout;


		if (temp == 4)
		{
			EndLevelTrigger();
		}
	}

	public void EndLevelTrigger()
	{
		objectives.text = "Leave the house";
		Door.enabled = true;
	}
}
