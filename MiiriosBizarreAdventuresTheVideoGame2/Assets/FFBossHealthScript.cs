using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFBossHealthScript : MonoBehaviour, Shootable
{
	public int HP = 25;
	public Slider Slide;

	void Shootable.GetShot()
	{
		HP--;
		Slide.value = HP;
		if (HP == 0)
		{
			Debug.Log("You Win");
		}
	}
}
