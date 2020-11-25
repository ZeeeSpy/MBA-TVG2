using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationItem : MonoBehaviour, DanganSpeech
{
	public string CharacterName = "Miirio's Thoughts";
	private string[] Dialogue;
	public TextAsset TA;
	public DanganRoomCameraController Room;

	private void Start()
	{
		string [] temp = TA.text.Split('\n');
		string[] temp2 = new string[temp.Length + 1];
		for (int i = 1; i < temp.Length+1; i++)
		{
			temp2[i] = temp[i - 1];
		}
		Dialogue = temp2;
	}

	public void InteractWithObj()
	{
		DanganronpaSpeechController.instance.StartTalk(CharacterName, Dialogue, this);
	}

	public void StopInteract()
	{
		Room.Done();
	}
}
