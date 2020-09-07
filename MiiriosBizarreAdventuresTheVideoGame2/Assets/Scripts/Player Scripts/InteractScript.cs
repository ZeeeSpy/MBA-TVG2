/*
 *  Script used for all intreractable objects.
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractScript : MonoBehaviour
{
	public Text UIText;
	public Text interacticon;

	void Update()
	{
		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 3f))
		{
			interacticon.enabled = true;
			Interactable InteractedObject = hit.collider.GetComponent<Interactable>();
			if (InteractedObject != null)
			{
				if (Input.GetButtonDown("Interact"))
				{
					//Debug.Log("Interacted");
					Interact(hit);
				}
			} else
			{
				interacticon.enabled = false;
			}
		} else
		{
			interacticon.enabled = false;
		}


	}

	private void Interact(RaycastHit hit)
	{
		UIText.text = (hit.collider.GetComponent<Interactable>().InteractWithObject());
		StartCoroutine(ClearText());
	}

	private IEnumerator ClearText()
	{
		yield return new WaitForSeconds(10);
		UIText.text = "";
	}


	public void DiplayText(string textodisp)
    {
        //UIText.showtext(textodisp);
    }
}
