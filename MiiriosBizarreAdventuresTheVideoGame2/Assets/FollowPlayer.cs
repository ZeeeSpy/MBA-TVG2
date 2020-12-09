using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	public Transform Player;

    void Update()
    {
		transform.position = new Vector3(Player.position.x, transform.position.y, Player.position.z);
    }
}
