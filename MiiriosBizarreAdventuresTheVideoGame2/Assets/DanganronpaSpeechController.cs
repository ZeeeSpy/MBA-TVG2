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
	private bool[] CluesInDia;
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

	public void StartTalk(string incname, string[] incdia, DanganCharacter _incchar, bool[] CluesInDia)
	{
		SpeechSetUp(incname, incdia, CluesInDia);
		incChar = _incchar;
		StartedToTalk = true;
		dia = incdia;
	}

	public void StartTalk(string incname, string[] incdia, InvestigationItem _incItem, bool[] CluesInDia)
	{
		SpeechSetUp(incname, incdia, CluesInDia);
		incChar = null;
		incItem = _incItem;
		StartCoroutine(DelayASec());
	}

	private void SpeechSetUp(string incname, string[] incdia, bool[] _CluesInDia)
	{
		CluesInDia = _CluesInDia;
		HUD.SetActive(false);
		CharacterSpeech.enabled = true;
		TextName.text = incname;
		TextDialogue.text = incdia[0];
		dia = incdia;
		if (CluesInDia[0])
		{
			Debug.Log("there's a clue here!");
		}
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
					if (CluesInDia[diacount])
					{
						Debug.Log("there's a clue here!");
					}
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
