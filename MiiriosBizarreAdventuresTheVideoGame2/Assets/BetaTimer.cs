using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetaTimer : MonoBehaviour
{
	float seconds;
	int minutes;
	public Text Timer; 


    // Update is called once per frame
    void Update()
    {
		seconds += Time.deltaTime;

		int tempseconds = (int)seconds;
		if (tempseconds > 60)
		{
			minutes += 1;
			tempseconds = 0;
		}
		if (minutes > 60){
			minutes = 0;
		}
		Timer.text = minutes + ":" + tempseconds;
	}
}
