using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GoodMorningMonoJerry : MonoBehaviour,DanganSpeech
{
	private Image TVImg;
	private GameObject player;
	public string CharacterName;
	private string[] Dialogue;
	public TextAsset TA;

	public AudioClip MRMK, BeautifulLife, Box15;
	public AudioSource StageMusic;


	private void Start()
	{
		TVImg = GetComponent<Image>();
		TVImg.enabled = true;


		player = GameObject.FindGameObjectWithTag("Player");
		Dialogue = TA.text.Split('\n');


		player.GetComponent<FirstPersonController>().enabled = false;
		DanganronpaSpeechController.instance.StartTalk(CharacterName, Dialogue, this);
	}

	public void StopInteract()
	{
		TVImg.enabled = false;
		player.GetComponent<FirstPersonController>().enabled = true;
		StageMusic.clip = BeautifulLife;
		StageMusic.Play();
	}
}
