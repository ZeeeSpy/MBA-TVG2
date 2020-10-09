﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FFBossHealthScript : MonoBehaviour, Shootable
{
	public int HP = 25;
	public Slider Slide;

	public AudioSource ASP;
	public AudioClip Hitmarker;
	public Image hitmarkerimg;


	void Shootable.GetShot()
	{
		StartCoroutine(GotShot());
		HP--;
		Slide.value = HP;
		if (HP == 0)
		{
			Debug.Log("You Win");
		}
	}

	IEnumerator GotShot()
	{
		ASP.PlayOneShot(Hitmarker);
		hitmarkerimg.enabled = true;
		yield return new WaitForSeconds(0.2f);
		hitmarkerimg.enabled = false;
	}
}
