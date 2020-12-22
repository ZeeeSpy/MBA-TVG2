using System.Collections;
using UnityEngine;
using Danganmalder;

public class DanganDebate1 : DanganDebate0
{
	void Start()
	{
		CDM = ClassDebateManager.instance;
		CTMS = ClassTrialMasterScript.instance;
		CDM.SetDebateLength(7);
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
						//All bullets are correct in DanganDebate1
						Correct();
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
				CDM.SetDebateLength(7);
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
			CTMS.LookAtCharacter(Characters.TwitchChat);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			CTMS.LookAtCharacter(Characters.F_F);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			CTMS.LookAtCharacter(Characters.Lee);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			CTMS.LookAtCharacter(Characters.Bamco);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			CTMS.LookAtCharacter(Characters.Twitch);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			CTMS.LookAtCharacter(Characters.Miirio);
			while (!CTMS.LookingAtDirection)
			{
				yield return new WaitForSeconds(0.1f);
			}

			Statements[Count].SetActive(true);
			yield return new WaitForSeconds(Waittime);
			Statements[Count].SetActive(false);

			Count++;
			CDM.Progress();
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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

		string[] temp = new string[] { "That's not the inconsistency, let's try again" };
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
}
