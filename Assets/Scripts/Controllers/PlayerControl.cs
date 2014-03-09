using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		[HideInInspector]
		public bool
				facingRight = true;			// For determining which way the player is currently facing.
		[HideInInspector]
		public bool
				jump = false;				// Condition for whether the player should jump.
		private int justJump = 0;
		public int AfterJumpIgnore = 100;
		public float moveForce = 365f;			// Amount of force added to move the player left and right.
		public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
		public AudioClip[] jumpClips;			// Array of clips for when the player jumps.
		public float jumpForce = 1000f;			// Amount of force added when the player jumps.
		public AudioClip[] taunts;				// Array of clips for when the player taunts.
		public float tauntProbability = 50f;	// Chance of a taunt happening.
		public float tauntDelay = 1f;			// Delay for when the taunt should happen.


		private int tauntIndex;					// The index of the taunts array indicating the most recent taunt.
		private Transform groundCheck;			// A position marking where to check if the player is grounded.
		private bool grounded = false;			// Whether or not the player is grounded.
		private Animator anim;					// Reference to the player's animator component.

		public float groundCheckRadius = 0.5f;
		private LayerMask walkableLayerMask;
		private int playerLayer;
		public int PlayerNumber;
		private bool falling = false;
		private PlayerAudioManager audioManager;
		private int timerSoundWalk;
		private WeaponController weaponController;

		void Awake ()
		{
				// Setting up references.
				groundCheck = transform.Find ("groundCheck");
				//anim = GetComponent<Animator>();
				walkableLayerMask = (1 << LayerMask.NameToLayer ("Ground")) | (1 << LayerMask.NameToLayer ("OneWayPlatform")); 
				
		}

		void Start ()
		{
				audioManager = GetComponent<PlayerAudioManager> ();
				weaponController = GetComponentInChildren<WeaponController> ();
				anim = GetComponent<Animator> ();
				playerLayer = LayerMask.NameToLayer ("Player" + PlayerNumber);
				timerSoundWalk = 0;
		}

		void OnDrawGizmos ()
		{
				Gizmos.DrawSphere (transform.Find ("groundCheck").position, groundCheckRadius);
		}

//		void FixedUpdate ()
//		{
//				float v = Input.GetAxis ("Vertical_Player" + PlayerNumber);
//				float h = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
//				bool lastValueGrounded = grounded;
//				grounded = Physics2D.OverlapCircle (groundCheck.position,
//                                   groundCheckRadius,
//                                   walkableLayerMask
//				);
//
//				if (lastValueGrounded == false && grounded == true) { // le joeuur attérit
//						audioManager.PlaySound (audioManager.atterissage);
//				}
//
//		if ((!grounded || rigidbody2D.velocity.y > 0 || v < 0 || justJump > 0) && justJump %5 == 0 && false) {
//						Debug.Log ("Grounded:" + !grounded);
//						Debug.Log ("Velo: " + rigidbody2D.velocity.y);
//						Debug.Log ("v:" + v);
//					Debug.Log ("JustJump:" + justJump);
//					Debug.Log ("Overall:" + (!grounded || rigidbody2D.velocity.y > 0 || v < 0 || (justJump > 0)));
//				}
//				Physics2D.IgnoreLayerCollision (playerLayer,
//                       LayerMask.NameToLayer ("OneWayPlatform"),
//                       !grounded || rigidbody2D.velocity.y > 0 || v < 0 || justJump > 0);// Cache the horizontal input.
//	
//		if (justJump > 0)
//						justJump--;
//
//
//				// The Speed animator parameter is set to the absolute value of the horizontal input.
//				//anim.SetFloat("Speed", Mathf.Abs(h));
//		
//				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
//				if (h * rigidbody2D.velocity.x < maxSpeed) {
//						// ... add a force to the player.
//						float airRatio = 1.0f;//grounded ? 1.0f : 0.5f;
//						rigidbody2D.AddForce (Vector2.right * h * moveForce * airRatio);
//				}
//
//				if (h != 0) {
//
//			timerSoundWalk++;
//			timerSoundWalk %= 60;
//			if (timerSoundWalk == 0) {
////						Debug.Log ("b");
//				audioManager.PlaySound(audioManager.marche);				
//			}
//
//
//				}
//
//				// If the player's horizontal velocity is greater than the maxSpeed...
//				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
//			// ... set the player's velocity to the maxSpeed in the x axis.
//						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
//
//				// If the input is moving the player right and the player is facing left...
//
//				if (h > 0 && !facingRight)
//			// ... flip the player.
//						Flip ();
//		// Otherwise if the input is moving the player left and the player is facing right...
//		else if (h < 0 && facingRight)
//			// ... flip the player.
//						Flip ();
//		
//
//				// If the player should jump...
//				if (jump) {
//						// Set the Jump animator trigger parameter.
//						//anim.SetTrigger("Jump");
//
//						// Play a random jump audio clip.
//						//int i = Random.Range(0, jumpClips.Length);
//						//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);
//
//						// Add a vertical force to the player.
////			if(v >=0 )
////			{
//			Physics2D.IgnoreLayerCollision (playerLayer,
//			                                LayerMask.NameToLayer ("OneWayPlatform"),true);
//						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
//						Debug.Log ("Jumping: " + jumpForce);
////			}
//
//		
//						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
//						jump = false;
//			justJump = AfterJumpIgnore;
//
//				}
//		}

		public float moveSpeed = 8;
		public float jumpSpeed = 25;
		public float fallSpeed = 64;
		public float maxFallSpeed = 50;
		public float maxUpSpeed = 25;
		Vector3 pos;
		float vm;
		bool onGround;
		
		// Update is called once per frame
		void FixedUpdate ()
		{
//		if (Input.GetButtonDown ("Jump_Player" + PlayerNumber) && grounded) {
//			jump = true;
//			audioManager.PlaySound (audioManager.saut);
//		}
//		
//		if (Input.GetButtonDown ("Fire1")) {
//			Debug.Log ("Fire1");
//			if (weaponController.swing ()) {
//				//anim.SetTrigger("Swing");
//			}
//		}


				bool lastValueGrounded = grounded;
				grounded = Physics2D.OverlapCircle (groundCheck.position,
		                                    groundCheckRadius,
		                                    walkableLayerMask
				);
		
//				if (lastValueGrounded == false && grounded == true) { // le joeuur attérit
//						audioManager.PlaySound (audioManager.atterissage);

				pos = transform.position;
				float v = Input.GetAxis ("Vertical_Player" + PlayerNumber);
				float h = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
				bool jump = Input.GetButtonDown ("Jump_Player" + PlayerNumber);
				bool action = Input.GetButtonDown ("Fire" + PlayerNumber);

				if (action) {
			weaponController.swing ();
				}
			
				if (onGround && jump) {
						vm = jumpSpeed;
				}
			
				Vector3 move = new Vector3 (h * moveSpeed, vm, 0) * Time.deltaTime;
				rigidbody.MovePosition (pos + move);
			
				if (v <= 0) {
						// gravity
						vm -= fallSpeed * Time.deltaTime;
				}
			
				vm = Mathf.Clamp (vm, -maxFallSpeed, maxUpSpeed);
			
				rigidbody.velocity = Vector3.zero;
				onGround = false;
//				}
		}
		
		void OnCollisionEnter (Collision c)
		{
				CheckCollision (c);
		}
		
		void OnCollisionStay (Collision c)
		{
				CheckCollision (c);    
		}
		
		void CheckCollision (Collision c)
		{
				foreach (var contact in c.contacts) {
						Debug.DrawLine (contact.point, contact.point + contact.normal, Color.red);
				
						// check for floor hit
						if (vm <= 0 && contact.point.y <= collider.bounds.min.y && Vector3.Angle (Vector3.up, contact.normal) <= 45) {
								onGround = true;
								vm = Mathf.Max (0, vm);
						}
				
						// check for head hit:
						if (contact.point.y >= collider.bounds.max.y && Vector3.Angle (-Vector3.up, contact.normal) <= 45) {
								vm = Mathf.Min (0, vm);
						}
				}
		}

		void Flip ()
		{
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				
				transform.rotation = Quaternion.Euler (0, !facingRight ? 180 : 0, 0);
		}


}
