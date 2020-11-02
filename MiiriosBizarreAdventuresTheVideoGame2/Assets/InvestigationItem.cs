using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigationItem : MonoBehaviour
{
	public string CharacterName;
	private string[] Dialogue;
	public TextAsset TA;
	public DanganRoomCameraController Room;

	private void Start()
	{
		Dialogue = TA.text.Split('\n');
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
