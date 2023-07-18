using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
	public BoxCollider2D GroundCollider;
	public PlayerController playerController;

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("Ready to Jump");
			playerController.isRedyJump = true;
		} 
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Debug.Log("Ready to Jump");
			playerController.isRedyJump = false;
		}
	}
}
