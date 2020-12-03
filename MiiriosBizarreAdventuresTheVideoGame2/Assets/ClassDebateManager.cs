using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassDebateManager : MonoBehaviour
{
	public TruthBulletScript[] TruthBulletArray;
	private int CurrentlyActiveBullet;

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
}
