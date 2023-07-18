using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
	public SpriteRenderer spriteRenderer;
	public BoxCollider2D groundCollider;
	public Rigidbody2D rb;
	public float playerSpeed, playerJump;
	public bool isRedyJump;

	private void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
        MoveSide();
		Jump();
		Fall();
	}
	public Vector3 MoveSide()
    {
		//if (!isRedyJump) return Vector3.zero;
        Vector3 dirMove = new Vector3();

        if (Input.GetKey(KeyCode.D)) dirMove += Vector3.right;
        else if (Input.GetKey(KeyCode.A)) dirMove += Vector3.left;
        dirMove *= playerSpeed * Time.deltaTime;
		animator.SetBool("isMove", dirMove != Vector3.zero);
		spriteRenderer.flipX = dirMove.x < 0;

		transform.position += dirMove;
        return dirMove.normalized;
    }
	public Vector3 Jump()
	{
		if (!isRedyJump)
		{
			//animator.SetBool("isJump", false);
			return Vector3.zero;
		}
		else
		{
			animator.SetBool("isJump", false);
		}

		if (Input.GetKeyDown(KeyCode.W)) 
		{
			rb.velocity = Vector3.up * playerJump;
			animator.SetBool("isJump", true);
			Debug.Log("Jump");
		}	

		return Vector3.zero;
	}
	public Vector3 Fall()
	{
		if (isRedyJump)
		{
			animator.SetBool("isFall", false);
			return Vector3.zero;
		}

		if(rb.velocity.y < 0)
		{
			animator.SetBool("isJump", false);
			animator.SetBool("isFall", true);
		}

		return Vector3.zero;
	}
}
