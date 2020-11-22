using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravestoneScript : MonoBehaviour, Interactable
{
	private bool inter = false;
	public string InteractWithObject()
	{
		if (!inter)
		{
			PayRespectsScript.instance.Checkin();
			inter = true;
		}
		return "";
	}
}
