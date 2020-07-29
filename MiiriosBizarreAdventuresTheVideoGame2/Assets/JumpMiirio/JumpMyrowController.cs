using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//stolen from https://www.youtube.com/watch?v=o4Z99Xi5xXc


public class JumpMyrowController : MonoBehaviour
{
	private float walkSpeed = 5;
	private float moveInput;
	public bool isGrounded;
	private Rigidbody2D rb;
	public LayerMask groundMask;

	public bool canJump = true;
	public float jumpValue = 0.0f;

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

		isGrounded = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.4f), new Vector2(0.7f, 0.25f), 0f, groundMask);

		if (jumpValue > 0)
		{
			rb.sharedMaterial = bounceMat;
		}
		else
		{
			rb.sharedMaterial = NormalMat;
		}

		if(Input.GetButton("Jump") && isGrounded && canJump)
		{
			jumpValue += 0.3f;
			rb.velocity = new Vector2(0.0f, rb.velocity.y);
		}



		if (jumpValue >= 21f && isGrounded)
		{
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
			canJump = true;
		}
	}

	private void ResetJump()
	{
		canJump = false;
		jumpValue = 0;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.4f), new Vector2(0.7f, 0.25f));
	}
}
