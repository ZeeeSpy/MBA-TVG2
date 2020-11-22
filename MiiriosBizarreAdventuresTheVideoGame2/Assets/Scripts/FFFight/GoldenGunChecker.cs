using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenGunChecker : MonoBehaviour
{
    
    void Start()
    {
		Image GunSprite = GetComponent<Image>();

		if (PlayerPrefs.GetInt("Gun") == 1)
		{
			GunSprite.color = new Color(176, 157, 0);
		}
	}
}
