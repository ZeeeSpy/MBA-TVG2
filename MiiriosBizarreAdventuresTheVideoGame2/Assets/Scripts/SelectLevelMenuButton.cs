using UnityEngine.SceneManagement;
using UnityEngine;

public class SelectLevelMenuButton : MonoBehaviour
{
	public void PlayGame(string LevelName)
	{
		SceneManager.LoadScene(LevelName);
	}
}
