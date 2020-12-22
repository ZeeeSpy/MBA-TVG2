using UnityEngine;

public class DanganLockedDoor : MonoBehaviour, Interactable
{
	private AudioSource AS;

	void Start()
	{
		AS = GetComponent<AudioSource>();
		AS.clip = AudioClipMaster.instance.GetClip(1);
	}

	public string InteractWithObject()
	{
		AS.Play();
		return null;
	}
}
