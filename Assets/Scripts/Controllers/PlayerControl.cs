using UnityEngine;
using System.Collections;


public class PlayerControl : MonoBehaviour
{
	// movement config
	public int PlayerNumber;
	public float gravity = -100f;
	public float runSpeed = 10f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 5f;
    public bool facingRight = true;


	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;
    private WeaponController wc;

	private PlayerAudioManager audioManager;
	private int timerSoundWalk;
	private bool wasJumping;



	void Awake()
	{
		//_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();
        wc = GetComponent<WeaponController>();
		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
		wasJumping = false;
        //if (!facingRight)
        //{
        //   gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        //}
	}


	void Start () {
		audioManager = GetComponent<PlayerAudioManager> ();
	}

	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion


	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
			
	
		// grab our current _velocity to use as a base for all calculations
		float horizontal = Input.GetAxis ("Horizontal_Player" + PlayerNumber);
		bool jump = Input.GetButtonDown ("Jump_Player" + PlayerNumber);
		bool action = Input.GetButtonDown ("Fire_Player" + PlayerNumber);

		_velocity = _controller.velocity;

        if (action)
        {
            wc.swing();
        }

		if( _controller.isGrounded )
			_velocity.y = 0;

		if( horizontal > 0 )
		{
			if(!facingRight)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
			}
            facingRight = true;
            //Debug.Log(facingRight.ToString());
			normalizedHorizontalSpeed = 1;

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( horizontal < 0 )
		{
			if(facingRight)
			{
				transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
			}
            facingRight = false;
			normalizedHorizontalSpeed = 1;

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;

			//if( _controller.isGrounded )
				//_animator.Play( Animator.StringToHash( "Idle" ) );
		}

		if(wasJumping && _controller.isGrounded) {
			wasJumping = false;
			audioManager.PlaySound(audioManager.atterissage);
		}


		// we can only jump whilst grounded
		if( _controller.isGrounded && jump )
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			audioManager.PlaySound(audioManager.saut);
			wasJumping = true;
			//_animator.Play( Animator.StringToHash( "Jump" ) );
		}



		// apply horizontal speed smoothing it
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
//		Debug.Log (_velocity);
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );
//		Debug.Log (_velocity);

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		_controller.move( _velocity * Time.deltaTime );

	}

	void FixedUpdate () {
		if (_velocity.x != 0) {
			
			timerSoundWalk++;
			timerSoundWalk %= 60;
			if (timerSoundWalk == 0) {
				audioManager.PlaySound(audioManager.marche);	
			}
		}
	}
}
