using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stolen from https://www.youtube.com/watch?v=o4Z99Xi5xXc


public class JumpMyrowController : MonoBehaviour
{
	public LayerMask groundMask;
	private float walkSpeed = 5;
	private float moveInput;
	public bool isGrounded;
	private Rigidbody2D rb;
	

	private const float maxjump = 21f;
	public bool canJump = true;
	public bool PressingSpace = false;
	public float jumpValue = 0.0f;
	public float devvalue = 0;

	private bool bouncing = false;

	public PhysicsMaterial2D bounceMat, NormalMat;

    void Start()
    {
		rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		moveInput = Input.GetAxisRaw("Horizontal");

		if (jumpValue == 0 && isGrounded)
		{
			rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y);
		}

		isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.4f), 
			new Vector2(0.7f, 0.3f), 0f, groundMask);

		if (!isGrounded && canJump == false)
		{
			if (!bouncing)
			{
				StartCoroutine(StopBounce());
			}
		}
		else
		{
			rb.sharedMaterial = NormalMat;
			bouncing = false;
		}


		if(Input.GetButton("Jump") && isGrounded && canJump)
		{
			jumpValue += 0.4f;
			rb.velocity = new Vector2(0.0f, rb.velocity.y);
			PressingSpace = true;
		} else
		{
			PressingSpace = false;
		}

		if (jumpValue >= maxjump && isGrounded)
		{
			if (devvalue != 0)
			{
				jumpValue = devvalue;
			}


			float tempx = moveInput * walkSpeed;
			float tempy = jumpValue;
			rb.velocity = new Vector2(tempx, tempy);
			Invoke("ResetJump", 0.1f);
		}

		if (Input.GetButtonUp("Jump"))
		{
			if (isGrounded)
			{
				rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
				jumpValue = 0;
			}
		}

		if (isGrounded)
		{
			canJump = true;
		}
	}

	private void ResetJump()
	{
		canJump = false;
		jumpValue = 0;
	}

	IEnumerator StopBounce()
	{
		bouncing = true;
		rb.sharedMaterial = bounceMat;
		yield return new WaitForSeconds(0.2f);
		rb.sharedMaterial = NormalMat;
	}

	//For debugging landing collisions
	/*
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.4f), new Vector2(0.81f, 0.25f));
	}
	*/
}
