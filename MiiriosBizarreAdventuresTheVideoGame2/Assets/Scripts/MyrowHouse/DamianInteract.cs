using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamianInteract : MonoBehaviour,  Interactable 
{
	public AudioSource MyrowAudio;
	public AudioClip FuckOff;
	private bool Done = false;
	public GameObject DamianScreen;
	public GameObject BlackScreen;
	public string InteractWithObject()
	{
		if (!Done)
		{
			DamianScreen.SetActive(false);
			BlackScreen.SetActive(true);
			MyrowAudio.PlayOneShot(FuckOff);
			Level1ObjectivesScript.Instance.UpdateObjectives(1);
			Done = true;
		}
		return "";
	}
}
