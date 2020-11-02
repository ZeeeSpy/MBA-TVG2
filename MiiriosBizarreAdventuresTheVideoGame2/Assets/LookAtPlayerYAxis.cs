using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerYAxis : MonoBehaviour
{
	private Transform playerlocation;

	void Start()
	{
		playerlocation = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void LateUpdate()
	{
		var lookPos = playerlocation.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = rotation;
	}
}
