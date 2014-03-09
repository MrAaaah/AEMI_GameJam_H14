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
		void FixedUpdate (){
				bool lastValueGrounded = grounded;
				grounded = IsGrounded ();
				if (!lastValueGrounded && grounded) { // le joeuur attérit
						audioManager.PlaySound (audioManager.atterissage);
				}
	
				pos = transform.position;
				float horizontal = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
				float vertical = Input.GetAxis ("Vertical_Player" + PlayerNumber);
				bool jump = Input.GetButtonDown ("Jump_Player" + PlayerNumber);
			
				if (grounded && horizontal != 0) {
						timerSoundWalk++;
						timerSoundWalk %= 60;
						if (timerSoundWalk == 0) {
								audioManager.PlaySound (audioManager.marche);				
						}
				}
			
				if (grounded && jump) {
						moveVertical = jumpSpeed;
				}
			
				Vector3 move = new Vector3 (horizontal * moveSpeed, moveVertical, 0) * Time.deltaTime;
				rigidbody.MovePosition (pos + move);
			
				if (!grounded && vertical <= 0) {
						// gravity
						moveVertical -= fallSpeed * Time.deltaTime;
				}
			
				moveVertical = Mathf.Clamp (moveVertical, -maxFallSpeed, maxUpSpeed);
			
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
				CheckCollision (c);    
		}
		
		void CheckCollision (Collision c)
		{
				foreach (var contact in c.contacts) {			
						// check for floor hit
						if (moveVertical <= 0 && contact.point.y <= collider.bounds.min.y && Vector3.Angle (Vector3.up, contact.normal) <= 20) {
				
								Debug.DrawLine (contact.point, contact.point + contact.normal, Color.red);
								grounded = true;
								moveVertical = Mathf.Max (0, moveVertical);
						}		
						// check for head hit:
						else if (contact.point.y >= collider.bounds.max.y && Vector3.Angle (-Vector3.up, contact.normal) <= 35) {
								Debug.DrawLine (contact.point, contact.point + contact.normal, Color.blue);
								moveVertical = Mathf.Min (0, moveVertical);
						} else {
								Debug.DrawLine (contact.point, contact.point + contact.normal, Color.gray);
						}
				}
		}
	
		void Flip ()
		{
				facingRight = !facingRight;
		
				// Multiply the player's x local scale by -1.
				transform.rotation = Quaternion.Euler (0, !facingRight ? 180 : 0, 0);
				weaponController.changeSideWeapon (facingRight);
		}


}
