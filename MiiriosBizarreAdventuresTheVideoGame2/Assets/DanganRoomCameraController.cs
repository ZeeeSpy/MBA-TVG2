using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanganRoomCameraController : MonoBehaviour
{
	public Transform Spinner;
	public Camera thisCam;
	public Transform Reset;
	private float moveInput;
	private float TurnSpeed = 1.5f;
	private const int MaxRotation = 40;
	private const float zoomspeed = 20f;

	public bool Zoom =false;
	private bool UnZoom = false;

	private Vector3 oldposition;
	private Vector3 TargetPosition;
	private Vector3 ClickedObjectPosition;
	public Vector3 oldrotation;

	private float currentRotation;

	public void FixedUpdate()
	{
		moveInput = Input.GetAxisRaw("Horizontal");

		if (moveInput != 0)
		{
			moveInput = moveInput * TurnSpeed;
			currentRotation += moveInput;
			currentRotation = Mathf.Clamp(currentRotation, -MaxRotation, MaxRotation);

			Spinner.localEulerAngles = new Vector3(Spinner.localEulerAngles.x, currentRotation, Spinner.localEulerAngles.z);
		}

		if (Input.GetMouseButtonDown(0))
		{ 
			Ray ray = thisCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				oldposition = transform.position;
				oldrotation = transform.eulerAngles;
				ClickedObjectPosition = hit.transform.position;
				TargetPosition = (oldposition + ClickedObjectPosition) / 2;
				Zoom = true;
			}
		}

		if (Input.GetMouseButtonDown(1))
		{
			UnZoom = true;
			TargetPosition = oldposition;
		}

		if (Zoom)
		{
			float step = zoomspeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

			Vector3 DirectionToRotate = ClickedObjectPosition - transform.position;
			Vector3 newDirection = Vector3.RotateTowards(transform.forward, DirectionToRotate, step,0.0f);
			transform.rotation = Quaternion.LookRotation(newDirection);

			if (Vector3.Distance(transform.position, TargetPosition) == 0){
				Zoom = false;
			}
		}


		if (UnZoom)
		{
			float step = zoomspeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(oldrotation), Time.time * zoomspeed);

			if (Vector3.Distance(transform.position, TargetPosition) == 0)
			{
				UnZoom = false;
			}
		}
	}


}
