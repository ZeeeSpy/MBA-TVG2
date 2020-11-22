using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelInteract : MonoBehaviour, Interactable
{
	public string LevelName;

	string Interactable.InteractWithObject()
	{
		SceneManager.LoadSceneAsync(LevelName);
		return "Loading Next level Please Wait";
	}
}
