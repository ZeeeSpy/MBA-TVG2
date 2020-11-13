using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteractScript : MonoBehaviour, Interactable
{

	public AudioSource AS;
	public AudioClip[] AC;
	public AudioClip Beep;

	bool oneshot = true;

	private void Start()
	{
		AS = GetComponent<AudioSource>();
	}

	string Interactable.InteractWithObject()
	{
		if (oneshot)
		{
			oneshot = false;
			StartCoroutine(PlayVoiceMails());
		}
		return "";
	}

	IEnumerator PlayVoiceMails()
	{
		for (int i = 0; i < AC.Length; i++)
		{
			AS.PlayOneShot(Beep);
			yield return new WaitForSeconds(Beep.length);

			AS.PlayOneShot(AC[i]);
			yield return new WaitForSeconds(AC[i].length);
		}

		AS.PlayOneShot(Beep);
		yield return new WaitForSeconds(Beep.length);
		Level1ObjectivesScript.Instance.UpdateObjectives(0);
	}
}
