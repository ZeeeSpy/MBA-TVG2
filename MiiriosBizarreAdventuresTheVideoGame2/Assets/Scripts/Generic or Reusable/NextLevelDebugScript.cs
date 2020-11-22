using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelDebugScript : MonoBehaviour, Interactable
{
	public string InteractWithObject()
	{
		Level1ObjectivesScript.Instance.EndLevelTrigger();
		return "Debug Level Finished";
	}
}
