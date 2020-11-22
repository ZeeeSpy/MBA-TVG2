﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{

	private void Awake()
	{
		Cursor.visible = true;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("Level1-MyrowHouse");
	}

	public void LevelSelect()
	{

	}

	public void Quit()
	{
		Application.Quit();
	}
}