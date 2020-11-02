using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DanganronpaSpeechController : MonoBehaviour
{
	public static DanganronpaSpeechController instance;

	public Image CharacterSpeech;
	public Text TextName;
	public Text TextDialogue;
	public GameObject HUD;

	private DanganCharacter incChar;
	private InvestigationItem incItem;
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

	public void StartTalk(string incname, string[] incdia,DanganCharacter _incchar)
	{
		HUD.SetActive(false);
		incChar = _incchar;
		CharacterSpeech.enabled = true;
		StartedToTalk = true;
		TextName.text = incname;
		dia = incdia;
		TextDialogue.text = incdia[0];
	}

	public void StartTalk(string incname, string[] incdia, InvestigationItem _incItem)
	{
		HUD.SetActive(false);
		CharacterSpeech.enabled = true;
		TextDialogue.text = incdia[0];
		TextName.text = incname;
		dia = incdia;
		incChar = null;
		incItem = _incItem;

		StartCoroutine(DelayASec());
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
					if (incChar != null)
					{
						incChar.StopInteract();
					}
					else
					{
						incItem.StopInteract();
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

	IEnumerator DelayASec()
	{
		yield return new WaitForSeconds(0.1f);
		StartedToTalk = true;
	}
}
