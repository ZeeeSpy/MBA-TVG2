using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassTrialMasterScript : MonoBehaviour
{
	private float[] CharacterRotationalValues = new float[] {0,45,90,135,180,225,270,315};
	public Quaternion TargetDirection;
	public bool LookingAtDirection = false;

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

	}

	private void LookAtCharacter(Characters inc)
	{
		LookingAtDirection = false;
		TargetDirection = Quaternion.Euler(0, CharacterRotationalValues[(int)inc], 0);
	}

	void FixedUpdate()
	{
		if (!LookingAtDirection)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetDirection, 100*Time.deltaTime);

			if (transform.rotation == TargetDirection)
			{
				LookingAtDirection = true;
			}
		}
	}
}
