using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Danganmalder;

public class DanganDebateTemplate : MonoBehaviour
{
	public int correctBullet;

	public GameObject[] StatmentArr;
	public string[] CharacterOrder;

	private ClassDebateManager CDM;
	private ClassTrialMasterScript CTMS;

	private void Start()
	{
		CDM = ClassDebateManager.instance;
		CTMS = ClassTrialMasterScript.instance;
		StartCoroutine(StartDebate());
		
	}

	IEnumerator StartDebate()
	{
		/*


		*/


		//look at character
		CTMS.LookAtCharacter(Characters.Miirio);
		//Wait until we're looking at character
		while (!CTMS.LookingAtDirection)
		{
			yield return new WaitForSeconds(0.1f);
		}
		//Spawn in text boxes


		//Set next box
		CDM.Progress();

		//repeat 

	}
}
