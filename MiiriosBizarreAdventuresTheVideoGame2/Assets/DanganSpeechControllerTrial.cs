using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanganSpeechControllerTrial : MonoBehaviour
{
	public static DanganSpeechControllerTrial instance;

	public Image CharacterSpeech;
	public Text TextName;
	public Text TextDialogue;
	public GameObject HUD;

	public ClassTrialMasterScript CTMS;
	private string[] dia;
	private int diacount = 1;

	public bool StartedToTalk = false;

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

	public void Speech(string incname, string[] incdia)
	{
		HUD.SetActive(true);
		CharacterSpeech.enabled = true;
		TextName.text = incname;
		TextDialogue.text = incdia[0];
		dia = incdia;
		StartedToTalk = true;
	}

	private void Update()
	{
		if (StartedToTalk)
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (diacount == dia.Length)
				{
					CharacterSpeech.enabled = false;
					StartedToTalk = false;
					TextName.text = "";
					TextDialogue.text = "";
					diacount = 1;
					HUD.SetActive(true);
					if (!CTMS.IsDebate)
					{
						CTMS.Next();
					}
				}
				else
				{
					TextDialogue.text = dia[diacount];
					diacount += 1;
				}
			}
		}
	}
}