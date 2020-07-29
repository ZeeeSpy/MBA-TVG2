using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JMCameraSwitcher : MonoBehaviour
{
	public GameObject BottomCam;
	public GameObject TopCam;

	public void EnterMyrow(bool isTop)
	{
		if (isTop)
		{
			TopCam.SetActive(true);
			BottomCam.SetActive(false);
		}
		else
		{
			TopCam.SetActive(false);
			BottomCam.SetActive(true);
		}
	}
}
