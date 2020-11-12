using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationItem : MonoBehaviour
{
	public string CharacterName;
	private string[] Dialogue;
	private bool[] CluesInDia;
	public TextAsset TA;
	public DanganRoomCameraController Room;

	private void Start()
	{
		Dialogue = TA.text.Split('\n');

		CluesInDia = new bool[Dialogue.Length];
		for (int i = 0; i < Dialogue.Length; i++)
		{
			if (Dialogue[i].EndsWith("0"))
			{
				Dialogue[i] = Dialogue[i].Remove(Dialogue[i].Length - 1, 1);
				CluesInDia[i] = true;
			}
			else
			{
				CluesInDia[i] = false;
			}
		}
	}

	public void InteractWithObj()
	{
		DanganronpaSpeechController.instance.StartTalk(CharacterName, Dialogue, this,CluesInDia);
	}

	public void StopInteract()
	{
		Room.Done();
	}
}
