using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanganDoorSwitcher : MonoBehaviour, Interactable
{
	private GameObject Core;
	public GameObject Inside;
	private AudioSource AS;

    void Start()
    {
		Core = GameObject.Find("Core");
		AS = GetComponent<AudioSource>();
		AS.clip = AudioClipMaster.instance.GetClip(0);
    }

	public string InteractWithObject()
	{
		Core.SetActive(false);
		Inside.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		AS.Play();
		return null;
	}

	public void ExitRoom()
	{
		Inside.SetActive(false);
		//spin player
		Core.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		AS.Play();
	}
}
