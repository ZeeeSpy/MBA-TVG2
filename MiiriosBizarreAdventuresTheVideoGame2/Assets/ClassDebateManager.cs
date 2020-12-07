using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassDebateManager : MonoBehaviour
{
	public TruthBulletScript[] TruthBulletArray;
	public GameObject ClassDebateObj;
	private int CurrentlyActiveBullet;
	public Image[] ProgressArr;
	int count = 0;

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
		ClassDebateObj.SetActive(true);

		for (int i = 0; i < TruthBulletArray.Length; i++)
		{
			TruthBulletArray[i].SetText("StringToSend");
		}
	}

	public int GetCurrentlyActiveBullet()
	{
		return CurrentlyActiveBullet;
	}


	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ProgressArr[count].color = new Color32(255, 182, 0, 255);
			if (count == 0)
			{
				ProgressArr[ProgressArr.Length-1].color = new Color32(255, 255, 255, 255);
			} else
			{
				ProgressArr[count - 1].color = new Color32(255, 255, 255, 255);
			}

			count++;
			if (count == ProgressArr.Length)
			{
				count = 0;
			}
		}
	}
}
