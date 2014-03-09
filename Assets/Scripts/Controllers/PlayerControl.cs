using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
		[HideInInspector]
		public bool
				facingRight = true;
		public int PlayerNumber;
		public float moveSpeed = 8;
		public float jumpSpeed = 25;
		public float fallSpeed = 64;
		public float maxFallSpeed = 50;
		public float maxUpSpeed = 25;
		private LayerMask walkableLayerMask;
		private int playerLayer;
		private bool falling = false;
		private PlayerAudioManager audioManager;
		private int timerSoundWalk;
		private WeaponController weaponController;
		private Vector3 pos;
		private float moveVertical;
		public bool grounded;

		void Awake ()
		{
				walkableLayerMask = (1 << LayerMask.NameToLayer ("Ground")) | (1 << LayerMask.NameToLayer ("OneWayPlatform")); 
				
		}

		void Start ()
		{
				audioManager = GetComponent<PlayerAudioManager> ();
				weaponController = GetComponentInChildren<WeaponController> ();
				playerLayer = LayerMask.NameToLayer ("Player" + PlayerNumber);
				timerSoundWalk = 0;
		}

		// Update is called once per frame
		void FixedUpdate ()
		{

				bool lastValueGrounded = grounded;

				if (!lastValueGrounded && grounded) { // le joeuur attérit
						audioManager.PlaySound (audioManager.atterissage);
				}

				pos = transform.position;
//				float vertical = Input.GetAxis ("Vertical_Player" + PlayerNumber);
				float horizontal = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
				bool jump = Input.GetButtonDown ("Jump_Player" + PlayerNumber);
                bool action = Input.GetButtonDown ("Fire" + PlayerNumber);

				if (action) {
			weaponController.swing ();


				if (grounded && jump) {
						moveVertical = jumpSpeed;
						audioManager.PlaySound (audioManager.saut);
				} else if (grounded && horizontal != 0) {
						timerSoundWalk++;
						timerSoundWalk %= 60;
						if (timerSoundWalk == 0) {
								audioManager.PlaySound (audioManager.marche);				
						}
				} else {
						moveVertical -= fallSpeed * Time.deltaTime;
						moveVertical = Mathf.Clamp (moveVertical, -maxFallSpeed, maxUpSpeed);
				}

				rigidbody.MovePosition (pos + new Vector3 (horizontal * moveSpeed, moveVertical, 0) * Time.deltaTime);
				rigidbody.velocity = Vector3.zero;
				grounded = false;

				if ((facingRight && horizontal < 0) || (!facingRight && horizontal > 0)) {
						Flip ();		
				}
		}
	
		void OnCollisionEnter (Collision c)
		{
				CheckCollision (c);
		}
		
		void OnCollisionStay (Collision c)
		{
				grounded = true;
				CheckCollision (c);    
		}
		
		void CheckCollision (Collision c)
		{
				foreach (var contact in c.contacts) {
						Debug.DrawLine (contact.point, contact.point + contact.normal, Color.red);
				
						// check for floor hit
						if (moveVertical <= 0 && contact.point.y <= collider.bounds.min.y && Vector3.Angle (Vector3.up, contact.normal) <= 50) {
								grounded = true;
								moveVertical = Mathf.Max (0, moveVertical);
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
