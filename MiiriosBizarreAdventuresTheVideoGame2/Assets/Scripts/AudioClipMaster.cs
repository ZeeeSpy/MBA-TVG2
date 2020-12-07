using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipMaster : MonoBehaviour
{
	public static AudioClipMaster instance;

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	public AudioClip[] Libraray;

	public AudioClip GetClip(int inc){
		return Libraray[inc];
	}
}
