using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGunPart : MonoBehaviour, Interactable
{
	GoldenGunScript GGS;

	public string InteractWithObject()
	{
		GGS.GetPart();
		Destroy(this.gameObject);
		return "";
	}

	void Start()
    {
		GGS = GoldenGunScript.Instance;
    }

    
}
