using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PayRespectsScript : MonoBehaviour
{
	public static PayRespectsScript instance;
	private bool firstsetup = true;
	private int count = 0;

	public Text PRText;

	public GameObject Sniper, SniperHud, Core, Video;
	public AudioSource AS;
	public AudioClip Intervention;

	void Start()
	{
		if (instance != this && instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
		}

		if (firstsetup)
		{
			firstsetup = false;
		}
	}


	public void Checkin()
	{
		count++;
		PRText.text = $"Pay Respects: {count}/10";

		if (count == 10)
		{
			Sniper.SetActive(true);
			SniperHud.SetActive(true);
			Core.SetActive(false);
			AS.Stop();
			AS.PlayOneShot(Intervention);
			StartCoroutine(SniperCo());
		}
	}

	IEnumerator SniperCo()
	{
		yield return new WaitForSeconds(1f);
		SniperHud.SetActive(false);
		Video.SetActive(true);
		yield return new WaitForSeconds(14.8f);
		SceneManager.LoadScene("Level2Boss");
	}
}
