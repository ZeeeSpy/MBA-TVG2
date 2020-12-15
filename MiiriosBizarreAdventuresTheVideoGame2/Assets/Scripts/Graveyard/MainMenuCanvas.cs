using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
	public GameObject MainButtons;
	public GameObject LevelButtons;

	private void Awake()
	{
		Cursor.visible = true;
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("Level1-MyrowHouse");
	}

	public void LevelSelectToggle()
	{
		MainButtons.SetActive(!MainButtons.activeInHierarchy);
		LevelButtons.SetActive(!LevelButtons.activeInHierarchy);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
