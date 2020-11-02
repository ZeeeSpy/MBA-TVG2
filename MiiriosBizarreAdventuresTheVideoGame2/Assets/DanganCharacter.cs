using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DanganCharacter : MonoBehaviour, Interactable
{
	private Vector3 startposition;
	private Transform playerlocation;
	GameObject player;
	public string CharacterName = "Placeholder";
	private string[]Dialogue = new string[5]{"Test 1","Test 2","Test 3","Test 4","Test 5"};


	public string InteractWithObject()
	{
		transform.position = playerlocation.position + playerlocation.forward;
		player.GetComponent<FirstPersonController>().enabled = false;
		DanganronpaSpeechController.instance.StartTalk(CharacterName,Dialogue, this);
		return null;
	}

	private void Start()
	{
		startposition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		playerlocation = player.transform;
	}

	public void StopInteract()
	{
		transform.position = startposition;
		player.GetComponent<FirstPersonController>().enabled = true;
	}
}
