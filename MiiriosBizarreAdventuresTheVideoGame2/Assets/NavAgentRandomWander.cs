using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavAgentRandomWander : MonoBehaviour
{
	private NavMeshAgent NMA;
	private Vector3 CurrentDestination;
	private Coroutine CR;
	private const float MinRange = 1.3f;

	public GameObject NodeParent;
	private Vector3[] ListOfNodes;
	private Transform Player;
	private PlayerScript PS;

	private LineRenderer LR;

	private bool searchlocked = false;
	private bool hasstopped = false;
	private bool StopLingRunning = false;

	private AudioSource AS;
	public AudioClip AC;


	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
		PS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

		ListOfNodes = new Vector3[NodeParent.transform.childCount];
		int temp = 0;
		foreach (Transform c in NodeParent.transform)
		{
			ListOfNodes[temp] = c.position;
			temp++;
		}


		NMA = GetComponent<NavMeshAgent>();
		CR = StartCoroutine(Wander());

		AS = GetComponent<AudioSource>();

		LR = GetComponent<LineRenderer>();
		Material RedMat = new Material(Shader.Find("Unlit/Color"));
		LR.material = RedMat;
		LR.material.color = Color.red;
	}

	IEnumerator Wander()
	{
		while (true)
		{
			GetNextDestination();
			yield return new WaitForSeconds(Random.Range(5, 20));
		}
	}

	private void Update()
	{
		if (Vector3.Distance(CurrentDestination, transform.position) < MinRange)
		{
			GetNextDestination();
		}

		RaycastHit hit;
		if (Physics.Linecast(transform.position, Player.position, out hit))
		{
			if (hit.transform.tag == "Player")
			{
				LR.enabled = true;
				GetFarDesination();
			}
			else
			{
				LR.enabled = false;
			}
		}

		LR.SetPosition(0, transform.position);
		LR.SetPosition(1, hit.point + new Vector3(0, 0.5f));
	}

	private void GetNextDestination()
	{
		CurrentDestination = ListOfNodes[Random.Range(0, ListOfNodes.Length)];
		NMA.SetDestination(CurrentDestination);
	}

	private void GetFarDesination()
	{
		if (!hasstopped)
		{
			if (!StopLingRunning)
			{
				StartCoroutine(StopLing());
			}
			else
			{
				return;
			}
		}

		if (!searchlocked)
		{
			StartCoroutine(LockSearch());
			Vector3 Furthest = ListOfNodes[0];
			float currentdistance = -100;

			for (int i = 0; i < ListOfNodes.Length; i++)
			{
				if (Vector3.Distance(ListOfNodes[i], Player.position) > currentdistance)
				{
					RaycastHit hit;
					if (Physics.Linecast(ListOfNodes[i], Player.position, out hit))
					{
						if (hit.transform.tag == "Player")
						{
							continue;
						}
						else
						{
							Furthest = ListOfNodes[i];
							currentdistance = Vector3.Distance(ListOfNodes[i], Player.position);
						}
					}
				}
			}
			CurrentDestination = Furthest;
			NMA.SetDestination(CurrentDestination);
		}
	}

	IEnumerator LockSearch()
	{
		searchlocked = true;
		yield return new WaitForSeconds(10f);
		searchlocked = false;
	}

	IEnumerator StopLing()
	{
		StopLingRunning = true;
		NMA.isStopped = true;

		AS.PlayOneShot(AC);
		yield return new WaitForSeconds(0.7f);
		RaycastHit hit;
		if (Physics.Linecast(transform.position, Player.position, out hit))
		{
			if (hit.transform.tag == "Player")
			{
				PS.Damage(3);
			}
			else
			{
				Debug.Log("Missed");
			}
		}

		yield return new WaitForSeconds(Random.Range(0.2f, 0.7f));
		NMA.isStopped = false;
		hasstopped = true;
		yield return new WaitForSeconds(10f);
		StopLingRunning = false;
		hasstopped = false;
	}


}