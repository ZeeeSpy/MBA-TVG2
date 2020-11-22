using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DanganCharacter : MonoBehaviour, Interactable, DanganSpeech
{
	private Vector3 startposition;
	private Transform playerlocation;
	GameObject player;
	public string CharacterName;
	private string[] Dialogue;
	public TextAsset TA;
	private bool interacted = false;

	private void Start()
	{
		startposition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		playerlocation = player.transform;

		Dialogue = TA.text.Split('\n');
	}

	public string InteractWithObject()
	{
		transform.position = playerlocation.position + playerlocation.forward;
		player.GetComponent<FirstPersonController>().enabled = false;
		DanganronpaSpeechController.instance.StartTalk(CharacterName,Dialogue, this);
		return null;
	}

	public void StopInteract()
	{
		transform.position = startposition;
		player.GetComponent<FirstPersonController>().enabled = true;
		if (!interacted)
		{
			interacted = true;
			CharacterTrackerDGR.instance.Talked();
		}
	}
}
