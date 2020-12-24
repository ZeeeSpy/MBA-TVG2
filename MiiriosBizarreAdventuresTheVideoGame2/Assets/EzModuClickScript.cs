using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EzModuClickScript : MonoBehaviour
{
	public bool Time = false;
	public Camera thisCam;
	public GameObject ToDisable;
	public GameObject ToEnable;


	public GameObject Popup;

	public GameObject ClickToOpenPopUp;

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
							Popup.SetActive(true);
							break;
						case 1:
							Popup.SetActive(false);
							ToDisable.SetActive(false);
							ToEnable.SetActive(true);
							ClickToOpenPopUp.SetActive(false);
							break;
						case 2:
							Popup.SetActive(false);
							break;
					}
				}				
			}
		}
	}
}
