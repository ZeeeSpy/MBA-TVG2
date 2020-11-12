using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteractScript : MonoBehaviour, Interactable
{

	public AudioSource AS;
	public AudioClip[] AC;

	private void Start()
	{
		AS = GetComponent<AudioSource>();
	}

	string Interactable.InteractWithObject()
	{
		StartCoroutine(PlayVoiceMails());
		return "";
	}

	IEnumerator PlayVoiceMails()
	{
		for (int i = 0; i < AC.Length; i++)
		{
			AS.PlayOneShot(AC[i]);
			yield return new WaitForSeconds(AC[i].length);
		}
		Level1ObjectivesScript.Instance.UpdateObjectives(0);
	}
}
