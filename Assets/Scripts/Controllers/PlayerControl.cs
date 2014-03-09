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
				playerLayer = LayerMask.NameToLayer ("Player" + PlayerNumber);
		}

		void Start ()
		{
				audioManager = GetComponent<PlayerAudioManager> ();
		weaponController = GetComponentInChildren<WeaponController> ();
		anim = GetComponent<Animator> ();
				timerSoundWalk = 0;
		}

		void Update ()
		{
				// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.

				// If the jump button is pressed and the player is grounded then the player should jump.
				if (Input.GetButtonDown ("Jump_Player" + PlayerNumber) && grounded) {
						jump = true;
						audioManager.PlaySound (audioManager.saut);
				}

		if (Input.GetButtonDown ("Fire1")) {
			Debug.Log ("Fire1");
			if(weaponController.swing())
			{
				//anim.SetTrigger("Swing");
			}
		}
		}

		void OnDrawGizmos ()
		{
				Gizmos.DrawSphere (transform.Find ("groundCheck").position, groundCheckRadius);
		}

		void FixedUpdate ()
		{
				float v = Input.GetAxis ("Vertical_Player" + PlayerNumber);
				float h = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
				bool lastValueGrounded = grounded;
				grounded = Physics2D.OverlapCircle (groundCheck.position,
                                   groundCheckRadius,
                                   walkableLayerMask
				);

				if (lastValueGrounded == false && grounded == true) { // le joeuur attérit
						audioManager.PlaySound (audioManager.atterissage);
				}

				Physics2D.IgnoreLayerCollision (playerLayer,
                       LayerMask.NameToLayer ("OneWayPlatform"),
                       !grounded || rigidbody2D.velocity.y > 0 || v < 0
				);// Cache the horizontal input.


				// The Speed animator parameter is set to the absolute value of the horizontal input.
				//anim.SetFloat("Speed", Mathf.Abs(h));
		
				// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
				if (h * rigidbody2D.velocity.x < maxSpeed) {
						// ... add a force to the player.
						float airRatio = 1.0f;//grounded ? 1.0f : 0.5f;
						rigidbody2D.AddForce (Vector2.right * h * moveForce * airRatio);
				}

				if (h != 0) {
			timerSoundWalk++;
			timerSoundWalk %= 60;
			if (timerSoundWalk == 0) {
						Debug.Log ("b");
				audioManager.PlaySound(audioManager.marche);				
			}

				}

				// If the player's horizontal velocity is greater than the maxSpeed...
				if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
						rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

				// If the input is moving the player right and the player is facing left...

				if (h > 0 && !facingRight)
			// ... flip the player.
						Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.
						Flip ();
		

				// If the player should jump...
				if (jump) {
						// Set the Jump animator trigger parameter.
						//anim.SetTrigger("Jump");

						// Play a random jump audio clip.
						//int i = Random.Range(0, jumpClips.Length);
						//AudioSource.PlayClipAtPoint(jumpClips[i], transform.position);

						// Add a vertical force to the player.
//			if(v >=0 )
//			{
						rigidbody2D.AddForce (new Vector2 (0f, jumpForce));
						Debug.Log ("Jumping: " + jumpForce);
//			}

		
						// Make sure the player can't jump again until the jump conditions from Update are satisfied.
						jump = false;
				}
		}
	
		void Flip ()
		{
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				
				transform.rotation = Quaternion.Euler(0,!facingRight?180:0,0);
				weaponController.changeSideWeapon (facingRight);
		}

		public IEnumerator Taunt ()
		{
				// Check the random chance of taunting.
				float tauntChance = Random.Range (0f, 100f);
				if (tauntChance > tauntProbability) {
						// Wait for tauntDelay number of seconds.
						yield return new WaitForSeconds (tauntDelay);

						// If there is no clip currently playing.
						if (!audio.isPlaying) {
								// Choose a random, but different taunt.
								tauntIndex = TauntRandom ();

								// Play the new taunt.
								audio.clip = taunts [tauntIndex];
								audio.Play ();
						}
				}
		}

		int TauntRandom ()
		{
				// Choose a random index of the taunts array.
				int i = Random.Range (0, taunts.Length);

				// If it's the same as the previous taunt...
				if (i == tauntIndex)
			// ... try another random taunt.
						return TauntRandom ();
				else
			// Otherwise return this index.
						return i;
		}


}
