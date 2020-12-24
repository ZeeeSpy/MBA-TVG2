using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextLevelAfterXSeconds : MonoBehaviour
{
	public AudioClip PMK;
	public AudioSource AS;
    void Start()
    {
		StartCoroutine(CountDown());
    }

	IEnumerator CountDown()
	{
		yield return new WaitForSeconds(14);
		AS.Stop();
		AS.clip = PMK;
		AS.Play();
		yield return new WaitForSeconds(37.5f);
		SceneManager.LoadScene("Level3-MaldKing");
	}
}
