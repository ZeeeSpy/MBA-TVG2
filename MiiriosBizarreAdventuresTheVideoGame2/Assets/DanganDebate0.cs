using System.Collections;
using UnityEngine;
using Danganmalder;

public class DanganDebate0 : MonoBehaviour
{
	public int correctBullet;

	public GameObject[] Statements;
	public string[] BulletNames = new string[]
	{
		"Highland Springs bottle","Miibio Stick","Salt Water"
	};
	private ClassDebateManager CDM;
	private ClassTrialMasterScript CTMS;
	int Count = 0;
	private float Waittime = 5;
	private Coroutine CurrentCoroutine;
	public Camera thisCam;
	private bool Restarting = false;

	private void Start()
	{
		CDM = ClassDebateManager.instance;
		CTMS = ClassTrialMasterScript.instance;
		CDM.SetDebateLength(3);
		CurrentCoroutine = StartCoroutine(StartDebate());
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = thisCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.GetComponent<Statement>() != null)
				{
					//If correct statement
					if (hit.transform.GetComponent<Statement>().IsStatementTrue())
					{
						//If correct bullet selected
						if (correctBullet == CDM.GetCurrentlyActiveBullet())
						{
							Correct();
						}
						else
						{
							Restart();
						}
					}
					else
					{
						Restart();
					}
				}
			}
		}

		if (Restarting)
		{
			if (!DanganSpeechControllerTrial.instance.StartedToTalk)
			{
				Count = 0;
				CDM.SetDebateLength(3);
				CurrentCoroutine = StartCoroutine(StartDebate());
				for (int i = 0; i < this.transform.childCount; i++)
				{
					var child = this.transform.GetChild(i).gameObject;
					if (child != null)
						child.SetActive(true);
				}
				Restarting = false;
			}
		}

	}

	IEnumerator StartDebate()
	{
		while (true)
		{
			CTMS.LookAtCharacter(Characters.XBOXGANG);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			CTMS.LookAtCharacter(Characters.TwitchChat);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Count++;
			CDM.Progress();

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();

			CTMS.LookAtCharacter(Characters.Miirio);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}
			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime * 2);
			Statements[Count].SetActive(false);
			Count = 0;
		}
	}

	private void Restart()
	{
		StopCoroutine(CurrentCoroutine);
		Debug.Log("Incorrect");

		foreach (GameObject A in Statements)
		{
			A.SetActive(false);
		}

		CTMS.LookAtCharacter(Characters.Miirio);

		for (int i = 0; i < this.transform.childCount; i++)
		{
			var child = this.transform.GetChild(i).gameObject;
			if (child != null)
				child.SetActive(false);
		}

		string[] temp = new string[]{ "That's not the inconsistency, let's try again" };
		DanganSpeechControllerTrial.instance.Speech("Miirio", temp);
		Restarting = true;
	}

	private void Correct()
	{
		foreach (GameObject A in Statements)
		{
			A.SetActive(false);
		}
		//NO THATS WRONG

		CDM.EndDebate();
	}

	public string[] ReturnBulletNames()
	{
		return BulletNames;
	}
}
