using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnZAxis : MonoBehaviour
{
	void Update()
	{
		transform.Rotate(new Vector3(Time.deltaTime * 0f, 0, 1f));
	}
}
