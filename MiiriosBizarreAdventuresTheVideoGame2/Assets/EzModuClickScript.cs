using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzModuClickScript : MonoBehaviour
{
	public bool Time = false;
	public Camera thisCam;
	string pass = "";
	string correctpass = "cbcdabba";
	bool activated = false;
	public GameObject ToDisable;
	public GameObject ToEnable;

	public GameObject EverythingElse;
	//Black Blue Green Blue Yellow Red Green Green Red

	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}


	void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = thisCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.GetComponent<EZModu>() != null && Time)
				{
					int value = hit.transform.GetComponent<EZModu>().GetValue();

					switch (value)
					{
						case -2:
							Application.OpenURL("https://www.twitch.tv/subs/ZeeeSpy");
							EverythingElse.SetActive(true);
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
						if (!activated)
						{
							activated = true;
							//Show video.
							ToDisable.SetActive(false);
							ToEnable.SetActive(true);
							EverythingElse.SetActive(false);
						}
					}
				}				
			}
		}
	}
}
