using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTrialMasterScript : MonoBehaviour
{
	private float[] CharacterRotationalValues = new float[] {0,45,90,135,180,225,270,315};
	public Quaternion TargetDirection;
	public bool LookingAtDirection = false;
	public ClassDebateManager CDM;

	public TextAsset TalkOrderTA;
	public TextAsset[] DialogueTA1;
	private string[][] DialogueStrings;
	private string[] TalkOrder;

	public AudioSource AS;
	public AudioClip DiscussionMusic;
	public AudioClip DebateMusic;

	private bool IsDebate = false;

	public int Count = -1;

	public enum Characters
	{
		TwitchChat =0,
		F_F,
		Lee,
		Brain,
		Bamco,
		Twitch,
		XBOXGANG,
		Miirio
	}

	private void Start()
	{
		TalkOrder = TalkOrderTA.text.Split('\n');

		DialogueStrings = new string[DialogueTA1.Length][];

		for (int i = 0; i < DialogueTA1.Length; i++)
		{
			DialogueStrings[i] = DialogueTA1[i].text.Split('\n');
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

				if (IsDebate)
				{
					//Class Debate Lookaround
				}
				else
				{
					DanganSpeechControllerTrial.instance.Speech(TalkOrder[Count], DialogueStrings[Count]);
				}
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
		} else
		{
			//Debate Section
			LookAtCharacter(Characters.Miirio);
			AS.Stop();
			AS.clip = DebateMusic;
			AS.Play();
			IsDebate = true;
			CDM.StartClassDebate();
		}
	}

	public void LookAtCharacter(Characters inc)
	{
		LookingAtDirection = false;
		TargetDirection = Quaternion.Euler(0, CharacterRotationalValues[(int)inc], 0);
	}

}
