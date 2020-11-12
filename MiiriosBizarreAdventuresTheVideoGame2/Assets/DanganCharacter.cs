using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DanganCharacter : MonoBehaviour, Interactable
{
	private Vector3 startposition;
	private Transform playerlocation;
	GameObject player;
	public string CharacterName;
	private string[] Dialogue;
	public TextAsset TA;
	public bool[] CluesInDia;
	private const string ClueText = "<color=yellow>";


	private void Start()
	{
		startposition = transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		playerlocation = player.transform;

		Dialogue = TA.text.Split('\n');

		CluesInDia = new bool[Dialogue.Length];
		for (int i = 0; i < Dialogue.Length; i++)
		{
			if (Dialogue[i].Contains(ClueText)) { 
				CluesInDia[i] = true;
			} else
			{
				CluesInDia[i] = false;
			}
		}
	}

	public string InteractWithObject()
	{
		transform.position = playerlocation.position + playerlocation.forward;
		player.GetComponent<FirstPersonController>().enabled = false;
		DanganronpaSpeechController.instance.StartTalk(CharacterName,Dialogue, this, CluesInDia);
		return null;
	}

	public void StopInteract()
	{
		transform.position = startposition;
		player.GetComponent<FirstPersonController>().enabled = true;
	}
}
