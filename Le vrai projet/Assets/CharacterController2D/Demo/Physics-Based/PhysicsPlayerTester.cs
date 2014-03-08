using UnityEngine;
using System.Collections;


public class PhysicsPlayerTester : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public bool dead = false;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private Animator _animator;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;

	// input
	private bool _right;
	private bool _left;
	private bool _up;

	private bool onIce = false;

	private bool barPressed = false;		//Checks if an axis is in motion




	void Awake()
	{
		_animator = GetComponent<Animator>();
		_controller = GetComponent<CharacterController2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}


	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		if(hit.transform.name == "IceBloc")
		{
			onIce = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{

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


	// the Update loop only gathers input. Actual movement is handled in FixedUpdate because we are using the Physics system for movement
	void Update()
	{
		movementChecks();

		if (Input.GetButton ("Fire1")) {
			onIce = true;
		} else 
		{
			onIce = false;
		}
		  
	}

	void movementChecks()
	{
		// a minor bit of trickery here. FixedUpdate sets _up to false so to ensure we never miss any jump presses we leave _up
		// set to true if it was true the previous frame
		_up = _up || Input.GetButtonDown("Jump" );

		var direction = 0f;

		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			direction = 1;
		}
		else if(Input.GetKey(KeyCode.LeftArrow)) 
		{
			direction = -1;
		}
		else
		{
			direction = 0;
		}

		if(Input.GetAxis("HorizontalJoy") != 0)
		{
			direction = Input.GetAxis("HorizontalJoy");
		}

		if (direction > 0) { //AxisDown
			_right = true;
			_left = false;
			barPressed = true;
		} else if (direction < 0) { //AxisUp
			_left = true;
			_right = false;
			barPressed = true;
		} else 
		{
			_left = false;
			_right = false;
			barPressed = false;
		}
	}

	void OnIceEnter()
	{
		onIce = true;
	}

	void OnIceExit()
	{
		onIce = true;
	}

	void Death()
	{
		dead = true;
	}

	void FixedUpdate()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
		
		if( _controller.isGrounded )
			_velocity.y = 0;
		
		if( _right )
		{
				normalizedHorizontalSpeed = 1;

			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			
			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else if( _left )
		{
			normalizedHorizontalSpeed = -1;

			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
			
			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Run" ) );
		}
		else
		{
			normalizedHorizontalSpeed = 0;
			
			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Idle" ) );
		}
		
		if(onIce)
		{
			groundDamping = 2;
		}
		else
			groundDamping = 10;

		// we can only jump whilst grounded
		if( _controller.isGrounded && _up )
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			_animator.Play( Animator.StringToHash( "Jump" ) );
		}
		
		
		// apply horizontal speed smoothing it
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.fixedDeltaTime * smoothedMovementFactor );
		
		// apply gravity before moving
		_velocity.y += gravity * Time.fixedDeltaTime;

		_controller.move( _velocity * Time.fixedDeltaTime );

		// reset input
		_up = false;
	}

}
