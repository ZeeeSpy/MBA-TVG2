using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentRandomWander : MonoBehaviour
{
	private NavMeshAgent NMA;
	private Vector3 CurrentDestination;
	private Coroutine CR;
	private const float MinRange = 1.3f;

	public GameObject NodeParent;
	private Vector3[] ListOfNodes;
	private Transform Player;

	private bool searchlocked = false;

    void Start()
    {
		Player = GameObject.FindGameObjectWithTag("Player").transform;

		ListOfNodes = new Vector3[NodeParent.transform.childCount];
		int temp = 0;
		foreach (Transform c in NodeParent.transform)
		{
			ListOfNodes[temp] = c.position;
			temp++;
		}


		NMA = GetComponent<NavMeshAgent>();
		CR = StartCoroutine(Wander());
    }

    IEnumerator Wander()
	{
		while (true) {
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
				GetFarDesination();
			}
		}
	}

	private void GetNextDestination()
	{
		CurrentDestination = ListOfNodes[Random.Range(0,ListOfNodes.Length)];
		NMA.SetDestination(CurrentDestination);
	}

	private void GetFarDesination()
	{
		if (!searchlocked)
		{
			Debug.Log("Searching For Furthest");
			StartCoroutine(LockSearch());
			Vector3 Furthest = ListOfNodes[0];
			float currentdistance = -100;

			for (int i = 0; i < ListOfNodes.Length; i++)
			{
				if (Vector3.Distance(ListOfNodes[i], Player.position) > currentdistance) {
					Furthest = ListOfNodes[i];
					currentdistance = Vector3.Distance(ListOfNodes[i], Player.position);
				}
			}
			CurrentDestination = Furthest;
			NMA.SetDestination(CurrentDestination);
		}
	}

	IEnumerator LockSearch()
	{
		searchlocked = true;
		yield return new WaitForSeconds(5f);
		searchlocked = false;
	}
}
