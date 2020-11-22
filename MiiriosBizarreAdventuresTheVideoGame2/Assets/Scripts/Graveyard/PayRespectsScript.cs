using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayRespectsScript : MonoBehaviour
{
	public static PayRespectsScript instance;
	private bool firstsetup = true;
	private int count = 0;

	private Text PRText;

	void Start()
	{
		if (instance != this && instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}

		if (firstsetup)
		{
			firstsetup = false;

			PRText = GetComponent<Text>();
		}
	}


	public void Checkin()
	{
		count++;
		PRText.text = $"Pay Respects: {count}/10";
	}
}
