using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTextReseter : MonoBehaviour
{
	public Text UIText;

	private void Start()
	{
		StartCoroutine(ResetText());
	}

	IEnumerator ResetText()
	{
		yield return new WaitForSeconds(15);
		UIText.text = "";
	}
}
