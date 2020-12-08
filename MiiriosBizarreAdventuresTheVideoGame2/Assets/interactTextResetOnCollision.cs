using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class interactTextResetOnCollision : MonoBehaviour
{
	public Text UIText;



	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			UIText.text = "";
		}
	}

}
