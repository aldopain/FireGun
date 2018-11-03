using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float Speed;
	public float JumpHeight;
	CharacterController cc;
	int IsGrounded = 0;
	public float Gravity;
	int Score;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}

	void Move () {
		var direction = new Vector3 (Speed, JumpHeight * TryJump () - AddGravity(), 0f);
		cc.Move (direction);
	}

	float AddGravity () {
		if (IsGrounded != 0)
			return Gravity;
		return 0f;
	}

	float TryJump () {
		if (Input.GetKeyDown ("space") && IsGrounded < 2) {
			IsGrounded++;
			return 1f;
		}
		return 0f;
	}

	void Die () {
		Destroy (gameObject);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		var tag = hit.collider.gameObject.tag;
		switch (tag) {
			case "Enemy":
				Die ();
				break;
			case "Ground":
				IsGrounded = 0;
				break;
			case "Fire":
				Score += 1;
				break;
			default:
				print ("unexpected tag: " + tag);
				break;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		Move ();
	}
}
