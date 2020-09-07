/*
 *  Script used to shoot. draws ray from player to cross hair, first collider that is hit is returned
 *  if it's shootable it is shot, otherwise nothing happens
 */

using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
	private GameObject CurrentlySelected;
    private Animator gunanimator;
    public AudioSource AS;
    public AudioClip[] GunShotSFX;
	private PlayerScript PS;

	public Animator[] GunAnimators;
	public GameObject[] GunGameObjects;
	private bool Waiting = false;
	private int CurrentWep = 0;
	private float[] GunTimes = new float[]{0f,0.8f};

	// Update is called once per frame

	private void Start()
	{
		PS = FindObjectOfType<PlayerScript>();
		CurrentlySelected = GunGameObjects[0];
		gunanimator = GunAnimators[0];
	}


	void Update()
    {
		if (Input.GetButton("Weapon 1"))
		{
			WeaponSwitch(0);
		}
		else if (Input.GetButton("Weapon 2"))
		{
			WeaponSwitch(1);
		}


		if (Input.GetButtonDown("Fire1") && !PS.IsDead() && !Waiting)
        {
            gunanimator.Play("Shoot");
            AS.PlayOneShot(GunShotSFX[CurrentWep]);
            BulletScript();
			StartCoroutine(WaitingNumerator());
        }
    }

	IEnumerator WaitingNumerator()
	{
		Waiting = true;
		yield return new WaitForSeconds(GunTimes[CurrentWep]);
		Waiting = false;
	}

	private void WeaponSwitch(int incnumb)
	{
		CurrentWep = incnumb;
		CurrentlySelected.SetActive(false);
		GunGameObjects[incnumb].SetActive(true);
		CurrentlySelected = GunGameObjects[incnumb];
		gunanimator = GunAnimators[incnumb];
	}

    public void BulletScript()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * 100000, out hit))
        {
            Shootable ObjectThatWasShot = hit.collider.GetComponent<Shootable>();

            if (ObjectThatWasShot != null)
            {
                ObjectThatWasShot.GetShot();
            }
        }
    }
}
