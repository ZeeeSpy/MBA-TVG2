using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BossInterventionSwitch : MonoBehaviour
{
	public ShootingScript SC;

	private void Awake()
	{
		StartCoroutine(PauseChamp());	
	}

	IEnumerator PauseChamp()
	{
		yield return new WaitForSeconds(0.01f);
		SC.InterventionLevel();
	}
}
