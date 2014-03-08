using UnityEngine;
using System.Collections;

public class PlayerTestController2 : MonoBehaviour {
	//http://www.gamedev.net/page/resources/_/technical/game-programming/the-guide-to-implementing-2d-platformers-r2936
	public bool facingRight;
	public bool isGrounded;

	Vector3 velocity = Vector3.zero;
	float fallingAcceleration = 0.5f;
	float acceleration = 0.05f;

	float maxSpeed = 3.0f;

	void Start () {
		facingRight = true;
	}

	void Update () {
		transform.position += velocity;  
	}

	void FixedUpdate () {
		RaycastFloor ();

		float h = Input.GetAxis("Horizontal");

		if (!isGrounded) {
			velocity.y -= fallingAcceleration * Time.fixedDeltaTime;
			velocity.y = Mathf.Clamp(velocity.y, -maxSpeed, maxSpeed);
		}
		else {
			velocity.y = 0;

			velocity.x += h * acceleration * Time.fixedDeltaTime;
			velocity.x = Mathf.Clamp(velocity.x, -maxSpeed, maxSpeed);
			
		}
	}

	void RaycastFloor () {
		Vector3 pos = transform.position;
		pos.y -= 1.5f;
		Vector3 step = new Vector3(1.5f, 0f, 0f);
		float rayLength = 1f;

		RaycastHit hit;
		if (Physics.Raycast(pos - step, Vector3.down, out hit, rayLength) ||
		    Physics.Raycast(pos, Vector3.down, out hit, rayLength) ||
		    Physics.Raycast(pos + step, Vector3.down, out hit, rayLength)) {
			isGrounded = true;
		}
		else {
			isGrounded = false;
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.d
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
