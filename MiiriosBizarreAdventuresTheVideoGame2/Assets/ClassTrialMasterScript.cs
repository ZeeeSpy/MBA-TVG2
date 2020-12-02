using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTrialMasterScript : MonoBehaviour
{
	private float[] CharacterRotationalValues = new float[] {0,45,90,135,180,225,270,315};
	public Quaternion TargetDirection;
	public bool LookingAtDirection = false;

	public TextAsset TalkOrderTA;
	public TextAsset[] DialogueTA;
	private string[][] DialogueStrings;
	private string[] TalkOrder;

	public int Count = -1;

	private enum Characters
	{
		TwitchChat =0,
		F_F,
		Lee,
		Brain,
		Bamco,
		Twitch,
		Xbox,
		Miirio
	}

	private void Start()
	{
		TalkOrder = TalkOrderTA.text.Split('\n');

		DialogueStrings = new string[DialogueTA.Length][];

		for (int i = 0; i < DialogueTA.Length; i++)
		{
			DialogueStrings[i] = DialogueTA[i].text.Split('\n');
		}

		Next();
	}


	void FixedUpdate()
	{
		if (!LookingAtDirection)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetDirection, 100*Time.deltaTime);

			if (transform.rotation == TargetDirection)
			{
				LookingAtDirection = true;
				DanganSpeechControllerTrial.instance.Speech(TalkOrder[Count], DialogueStrings[Count]);
			}
		}
	}

	public void Next()
	{
		Count++;
		if (Count != TalkOrder.Length)
		{
			Characters NextChar = (Characters)System.Enum.Parse(typeof(Characters), TalkOrder[Count]);
			LookAtCharacter(NextChar);
		}
	}

	private void LookAtCharacter(Characters inc)
	{
		LookingAtDirection = false;
		TargetDirection = Quaternion.Euler(0, CharacterRotationalValues[(int)inc], 0);
	}

}
