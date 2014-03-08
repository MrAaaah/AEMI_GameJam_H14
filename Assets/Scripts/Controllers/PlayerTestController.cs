using UnityEngine;
using System.Collections;

public class PlayerTestController : MonoBehaviour {
	//http://www.gamedev.net/page/resources/_/technical/game-programming/the-guide-to-implementing-2d-platformers-r2936
	public float maxSpeed;
	public float acceleration;	// est sensée etre variable je pense 

	public float rayBottomLength = 3f;
	public float raySideLength = 3f;
	public float rayOffset = 3f;

	public bool onGround;
	public bool isJumping;
	public bool collisionOnRight;
	public bool collisionOnLeft;
	

	public float fallSpeed;

	public Vector2 currentSpeed;

	public Vector2 targetSpeed;


	public float timerJumpDuration;
	public float timerJump;

	public bool isJumpingAndStillGoingUp;
	public bool canJump;

	public Vector3 raycastHitPoint;

	[HideInInspector]
	public bool facingRight = true;			// For determining which way the player is currently facing.
	
	// Use this for initialization
	void Start () {
		onGround = false;
	}
	
	// Update is called once per frame
	void Update () {
		DrawRay ();

		transform.position += new Vector3(currentSpeed.x, currentSpeed.y, 0) * Time.deltaTime;

		float h = Input.GetAxis("Horizontal");
		
		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
	}

	void UpdateJumpTimer () {
//		timer = timerDuration;
		if (timerJump > 0) {
			timerJump -= Time.deltaTime;
			if (timerJump <= 0) {
				timerJump = 0;
				isJumpingAndStillGoingUp = false;
			}
		}
	}

	void FixedUpdate () {
		RaycastFloor ();
		RaycastRight ();
		RaycastLeft ();

		
		
		if (onGround && !isJumpingAndStillGoingUp) {
			currentSpeed.y = 0;
		}
		
		
		UpdateJumpTimer ();
		
		if (Input.GetButton("Jump")) {
			if (onGround && canJump) {
				timerJump = timerJumpDuration;
				isJumpingAndStillGoingUp = true;
				canJump = false;
				isJumping = true;
			}
		}
		else {
			if (onGround) {
				canJump = true;
				isJumping = false;
			}
		}
		
		
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");
		
		targetSpeed.x = h * maxSpeed;
		
		if (isJumpingAndStillGoingUp) {
			targetSpeed.y = maxSpeed;
			if (!Input.GetButton("Jump")) {
				isJumpingAndStillGoingUp = false;
				timerJump = 0;
			}
		}
		else if (onGround) {
			targetSpeed.y = 0f;
		} 
		else if (collisionOnLeft && h < 0) {
			targetSpeed.x = 0f;
		}
		else if (collisionOnRight && h > 0) {
			targetSpeed.x = 0f;
		}
		else {
			targetSpeed.y = -fallSpeed;
		}
		
		
		Vector2 direction = new Vector2(Mathf.Sign(targetSpeed.x - currentSpeed.x), Mathf.Sign(targetSpeed.y - currentSpeed.y));
		
		currentSpeed += direction * acceleration;
		
		if (Mathf.Sign(targetSpeed.x - currentSpeed.x) != direction.x)
			currentSpeed.x = targetSpeed.x;
		if (Mathf.Sign(targetSpeed.y - currentSpeed.y) != direction.y)
			currentSpeed.y = targetSpeed.y;
		
		if (onGround && !isJumpingAndStillGoingUp) {
			currentSpeed.y = 0;
		}

		if (collisionOnLeft && h < 0) {
			currentSpeed.x = 0f;
		}
		if (collisionOnRight && h > 0) {
			currentSpeed.x = 0f;
		}
	}

	void RaycastFloor () {
		Vector3 pos = transform.position;
//		pos.y -= rayOffset;// - 1.5f;
		Vector3 step = new Vector3(1.5f, 0f, 0f);

		Color rayColor = Color.green;
		RaycastHit hit;
		if (Physics.Raycast(pos - step, Vector3.down, out hit, rayBottomLength) ||
		    Physics.Raycast(pos, Vector3.down, out hit, rayBottomLength) ||
		    Physics.Raycast(pos + step, Vector3.down, out hit, rayBottomLength)) {
			onGround = true;
			rayColor = Color.red;
			
		    if (!Input.GetButton("Jump")) {
				canJump = true;
			}
			else {
				isJumping = true;
			}
		}
		else {
			onGround = false;
		}
//			Debug.Log(onGround);
	}

	void RaycastRight () {
		Vector3 pos = transform.position;
//		pos.x += 2f;// - 1.5f;
		Vector3 step = new Vector3(0f, 1.5f, 0f);
		Color rayColor = Color.green;
		RaycastHit hit;
		if (Physics.Raycast(pos - step, Vector3.right, out hit, raySideLength) ||
		    Physics.Raycast(pos, Vector3.right, out hit, raySideLength) ||
		    Physics.Raycast(pos + step, Vector3.right, out hit, raySideLength)) {
			collisionOnRight = true;
		}
		else {
			collisionOnRight = false;
		}

		Debug.DrawLine(pos, pos + new Vector3(raySideLength, 0, 0), rayColor);
		pos.y-=1.5f;
		Debug.DrawLine(pos, pos + new Vector3(raySideLength, 0, 0), rayColor);
		pos.y+=3.5f;
		Debug.DrawLine(pos, pos + new Vector3(raySideLength, 0, 0), rayColor);
		
	}

	void RaycastLeft () {
		Vector3 pos = transform.position;
//		pos.x -= 2f;// - 1.5f;
		Vector3 step = new Vector3(0f, 1.5f, 0f);
		Color rayColor = Color.green;
		RaycastHit hit;
		if (Physics.Raycast(pos - step, Vector3.left, out hit, raySideLength) ||
		    Physics.Raycast(pos, Vector3.left, out hit, raySideLength) ||
		    Physics.Raycast(pos + step, Vector3.left, out hit, raySideLength)) {
			rayColor = Color.red;
			collisionOnLeft = true;
		}
		else {
			collisionOnLeft = false;
		}
		
		Debug.DrawLine(pos, pos - new Vector3(raySideLength, 0, 0), rayColor);
		pos.y-=1.5f;
		Debug.DrawLine(pos, pos - new Vector3(raySideLength, 0, 0), rayColor);
		pos.y+=3.5f;
		Debug.DrawLine(pos, pos - new Vector3(raySideLength, 0, 0), rayColor);
		
	}

	void DrawRay () {
		Vector3 pos = transform.position;
		pos.y -= rayOffset;

		Color rayColor = Color.green;

		if (onGround) {
			rayColor = Color.red;
		}

		Debug.DrawLine(pos, pos + new Vector3(0, -rayBottomLength, 0), rayColor);
		pos.x-=1.5f;
		Debug.DrawLine(pos, pos + new Vector3(0, -rayBottomLength, 0), rayColor);
		pos.x+=3.0f;
		Debug.DrawLine(pos, pos + new Vector3(0, -rayBottomLength, 0), rayColor);
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
