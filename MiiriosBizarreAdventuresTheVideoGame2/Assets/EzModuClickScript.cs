using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzModuClickScript : MonoBehaviour
{
    public Camera thisCam;
	string pass = "";
	string correctpass = "cbcdabba";
	//Blue Green Blue Yellow Red Green Green Red

    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = thisCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.GetComponent<EZModu>() != null)
				{
					int value = hit.transform.GetComponent<EZModu>().GetValue();

					switch (value)
					{
						case -2:
							Application.OpenURL("https://www.twitch.tv/subs/ZeeeSpy");
							//Todo show buttons and say it'll take a second to load
							break;
						case -1:
							pass = "";
							break;
						case 1:
							pass = pass + "a";
							break;
						case 2:
							pass = pass + "b";
							break;
						case 3:
							pass = pass + "c";
							break;
						case 4:
							pass = pass + "d";
							break;
					}

					Debug.Log(pass);
					if (pass == correctpass)
					{
						//toggle platforms to easy mode
						//Play video
					}
				}				
			}
		}
	}
}
