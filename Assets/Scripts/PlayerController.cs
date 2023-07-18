using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
	public SpriteRenderer spriteRenderer;
	public float playerSpeed;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
        MoveSide();
	}
	public Vector3 MoveSide()
    {
        Vector3 dirMove = new Vector3();

        if (Input.GetKey(KeyCode.D)) dirMove += Vector3.right;
        else if (Input.GetKey(KeyCode.A)) dirMove += Vector3.left;
        dirMove *= playerSpeed * Time.deltaTime;
		animator.SetBool("isMove", dirMove != Vector3.zero);
		spriteRenderer.flipX = dirMove.x < 0;

		transform.position += dirMove;
        return dirMove.normalized;
    }
}
