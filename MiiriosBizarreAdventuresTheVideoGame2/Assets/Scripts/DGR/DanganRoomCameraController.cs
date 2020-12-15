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
	//private const int MaxRotation = 40;
	private const int MaxRotation = 40;
	private int adjustment = 0;
	private const float zoomspeed = 20f;

	public bool Zoom =false;
	public bool UnZoom = false;
	public bool Zoomed = false;

	private Vector3 oldposition;
	private Vector3 TargetPosition;
	private Vector3 ClickedObjectPosition;
	public Vector3 oldrotation;

	private float currentRotation;

	public bool inverse = false;

	public void Start()
	{
		if (inverse)
		{
			adjustment = 180;
		}
	}

	public void FixedUpdate()
	{
		moveInput = Input.GetAxisRaw("Horizontal");

		if (moveInput != 0 && !Zoom && !Zoomed)
		{
			moveInput = moveInput * TurnSpeed;
			currentRotation += moveInput;
			currentRotation = Mathf.Clamp(currentRotation, -MaxRotation + adjustment, MaxRotation + adjustment);
			Spinner.localEulerAngles = new Vector3(Spinner.localEulerAngles.x, currentRotation, Spinner.localEulerAngles.z);
		}

		if (Input.GetMouseButtonDown(0) & !Zoomed)
		{ 
			Ray ray = thisCam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.GetComponent<InvestigationItem>() != null)
				{
					oldposition = transform.position;
					oldrotation = transform.eulerAngles;
					ClickedObjectPosition = hit.transform.position;
					TargetPosition = (oldposition + ClickedObjectPosition) / 2;
					Zoom = true;
					Zoomed = true;

					hit.transform.GetComponent<InvestigationItem>().InteractWithObj();
				}

				else if (hit.transform.GetComponent<DanganDoorSwitcher>() != null)
				{
					hit.transform.GetComponent<DanganDoorSwitcher>().ExitRoom();
				}
			}
		}

		if (Zoom)
		{
			float step = zoomspeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

			Vector3 DirectionToRotate = ClickedObjectPosition - transform.position;
			Vector3 newDirection = Vector3.RotateTowards(transform.forward, DirectionToRotate, step,0.0f);
			transform.rotation = Quaternion.LookRotation(newDirection);

			if (Vector3.Distance(transform.position, TargetPosition) < 0.01f){
				Zoom = false;
				TargetPosition = oldposition;
			} 
		}


		if (UnZoom)
		{
			float step = zoomspeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(oldrotation), Time.time * zoomspeed);

			if (Vector3.Distance(transform.position, TargetPosition) < 0.01f)
			{
				UnZoom = false;
				Zoomed = false;
			}
		}
	}


	public void Done()
	{
		UnZoom = true;
	}
}
