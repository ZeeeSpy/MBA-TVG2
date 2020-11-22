using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCameraSwitcher2 : MonoBehaviour
{
	private Camera ThisCam;

	private void Start()
	{
		ThisCam = GetComponent<Camera>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Myrow")
		{
			ThisCam.enabled = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.name == "Myrow")
		{
			ThisCam.enabled = false;
		}
	}
}
