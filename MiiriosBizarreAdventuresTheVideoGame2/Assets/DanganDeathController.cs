using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DanganDeathController : MonoBehaviour, DanganSpeech
{
	public Image Self;
	private GameObject player;
	public string CharacterName;
	private string[] Dialogue;
	public TextAsset TA;
	public Camera Cam;
	private bool happening;



	private void Start()
	{
		Dialogue = TA.text.Split('\n');
		DanganronpaSpeechController.instance.StartTalk(CharacterName, Dialogue, this);
	}

	public void StopInteract()
	{
		Self.enabled = false;
		happening = true;
		StartCoroutine(LoadNext());
	}

	void FixedUpdate()
	{
		if (happening)
		{
			Cam.fieldOfView -= 0.1f;
		}
	}

	IEnumerator LoadNext()
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene("Level4DanganTrial");
	}
}
