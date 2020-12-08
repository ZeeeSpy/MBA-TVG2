/*
 * Script that handles the pause menu in all scenes. 
 * Pause is done by setting time scale to 0 and unlocking cursor.
 * nothing fancy.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject pausemenu;
	private FirstPersonController Player;

	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
	}

	void Update()
    {
      if (Input.GetButtonDown("Cancel"))
        {
            if (!paused)
            {
                Time.timeScale = 0;
                paused = true;
            } else
            {
                Time.timeScale = 1;
                paused = false;
            }
        }

      if (paused)
        {
            pausemenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
			if (Player != null)
			{
				Player.enabled = false;
			}
        } else
        {
            pausemenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
			if (Player != null)
			{
				Player.enabled = true;
			}
		}
    }

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
