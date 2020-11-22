using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCameraTrigger : MonoBehaviour
{
	public JMCameraSwitcher CS;
	public bool top = true;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "Myrow")
		{
			CS.EnterMyrow(top);
		}
	}
}
