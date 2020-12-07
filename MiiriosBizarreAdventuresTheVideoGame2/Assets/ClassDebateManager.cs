using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassDebateManager : MonoBehaviour
{
	public static ClassDebateManager instance;
	public TruthBulletScript[] TruthBulletArray;
	private ClassTrialMasterScript CTMS;
	public GameObject ClassDebateObj;
	private int CurrentlyActiveBullet;
	public Image[] ProgressArrMaster;
	public DanganDebate0[] DanganDebateScripts;
	int DebateCount = 0;
	int count = 0;

	private int ThisDebateLength;

	public void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public void SetBulletAsActive(int inc)
	{
		CurrentlyActiveBullet = inc;
		for (int i = 0; i < TruthBulletArray.Length; i++)
		{
			if (i != inc)
			{
				TruthBulletArray[i].SetAsNotActive();
			}
		}
	}

	public void StartClassDebate()
	{
		CTMS = ClassTrialMasterScript.instance;
		CTMS.IsDebate = true;
		DanganDebateScripts[DebateCount].enabled = true;
		string[] temp = DanganDebateScripts[DebateCount].ReturnBulletNames();

		ToggleClassDebateObject();

		for (int i = 0; i < TruthBulletArray.Length; i++)
		{
			TruthBulletArray[i].SetText(temp[i]);
		}
	}

	public int GetCurrentlyActiveBullet()
	{
		return CurrentlyActiveBullet;
	}

	public void Progress()
	{
		ProgressArrMaster[count].color = new Color32(255, 255, 255, 255);

		count++;
		ProgressArrMaster[count].color = new Color32(255, 182, 0, 255);

		if (count == ThisDebateLength)
		{
			ProgressArrMaster[count].color = new Color32(255, 255, 255, 255);
			count = 0;
			ProgressArrMaster[count].color = new Color32(255, 182, 0, 255);
		}
	}


	public void SetDebateLength(int inc)
	{
		count = 0;
		ThisDebateLength = inc;

		//toggle all on
		foreach (Image A in ProgressArrMaster)
		{
			A.enabled = true;
			A.color = new Color32(255, 255, 255, 255);
		}


		//toggle uneeded off
		for (int i = ThisDebateLength; i < ProgressArrMaster.Length; i++)
		{
			ProgressArrMaster[i].enabled = false;
		}

		ProgressArrMaster[0].color = new Color32(255, 182, 0, 255);
	}


	public void EndDebate()
	{
		ToggleClassDebateObject();
		CTMS.IsDebate = false;
		CTMS.LoadNextDialogueSequence();
	}


	public void ToggleClassDebateObject()
	{
		ClassDebateObj.SetActive(!ClassDebateObj.activeInHierarchy);
	}
}
