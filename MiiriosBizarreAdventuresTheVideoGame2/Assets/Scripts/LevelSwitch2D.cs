using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch2D : MonoBehaviour
{
	public string nextscene;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(nextscene);
		}
	}
}
