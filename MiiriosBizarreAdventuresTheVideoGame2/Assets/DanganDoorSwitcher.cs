using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanganDoorSwitcher : MonoBehaviour, Interactable
{
	private GameObject Core;
	public GameObject Inside;

    void Start()
    {
		Core = GameObject.Find("Core");
    }

	public string InteractWithObject()
	{
		Core.SetActive(false);
		Inside.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		return null;
	}

	public void ExitRoom()
	{
		Inside.SetActive(false);
		Core.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	//add door sound
}
