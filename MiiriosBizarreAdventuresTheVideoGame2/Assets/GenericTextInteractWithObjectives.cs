using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTextInteractWithObjectives : MonoBehaviour, Interactable
{
	[TextArea(15, 20)]
	public string stringtoret;
	public int ObjectiveNumber = -1;

	public string InteractWithObject()
	{
		Level1ObjectivesScript.Instance.UpdateObjectives(ObjectiveNumber);
		return stringtoret;
	}
}

