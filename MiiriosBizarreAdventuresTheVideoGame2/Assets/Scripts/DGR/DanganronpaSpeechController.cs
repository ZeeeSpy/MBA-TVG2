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
	private GoodMorningMonoJerry incGM;

	DanganSpeech DGS;
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

	public void StartTalk(string incname, string[] incdia, DanganSpeech _DGS)
	{
		SpeechSetUp(incname, incdia);
		DGS = _DGS;
		StartedToTalk = true;
		dia = incdia;
	}


	private void SpeechSetUp(string incname, string[] incdia)
	{
		HUD.SetActive(false);
		CharacterSpeech.enabled = true;
		TextName.text = incname;
		TextDialogue.text = incdia[0];
		dia = incdia;
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
					DGS.StopInteract();
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
