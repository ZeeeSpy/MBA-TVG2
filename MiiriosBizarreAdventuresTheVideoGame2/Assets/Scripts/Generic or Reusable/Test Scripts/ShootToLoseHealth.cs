using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToLoseHealth : MonoBehaviour, Shootable
{
	void Shootable.GetShot()
	{
		FindObjectOfType<PlayerScript>().Damage(1);
	}
}
