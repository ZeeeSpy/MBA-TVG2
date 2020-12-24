using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaTimer : MonoBehaviour
{
	public float seconds;
	public int minutes;
	public int hours;
	public Text Timer;
	public EzModuClickScript EMCS;
	public GameObject PressMe;
	private bool acivated = false;


	// Update is called once per frame

	void Update()
    {
		seconds += Time.deltaTime;

		int tempseconds = (int)seconds;
		minutes = tempseconds / 60;
		hours = minutes / 60;
		tempseconds = tempseconds % 60;

		string tout = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, tempseconds);
		Timer.text = tout;

		if (minutes >= 15 && !acivated)
		{
			acivated = true;
			EMCS.Time = true;
			PressMe.SetActive(true);
		}
	}
}
