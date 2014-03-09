using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PhysicsPlayerTester : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	public bool dead = false;
	private bool propulsing = false;

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

	float propulseTimer = 1;
	float propulseTimerAcc = 0;

	public AudioClip jumpSound, deathSound;
	private bool deathSoundPlayed = false;


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
		if (!dead)
		{
			if (isDeadly(hit.collider.gameObject))
			{
				Death();
			}
		}
	}

	void onTriggerEnterEvent( Collider2D col )
	{
		if(col.gameObject.name == "Propulser")
		{
			Propulse();
		}
	}


	void onTriggerExitEvent( Collider2D col )
	{
	}

	#endregion


	// the Update loop only gathers input. Actual movement is handled in FixedUpdate because we are using the Physics system for movement
	void Update()
	{
		movementChecks();
		  
	}

	void movementChecks()
	{
		// a minor bit of trickery here. FixedUpdate sets _up to false so to ensure we never miss any jump presses we leave _up
		// set to true if it was true the previous frame
		_up = _up || Input.GetButtonDown("(P1) Jump" );

		var direction = 0f;

		if (Input.GetAxis("(P1) Horizontal") > 0) 
		{
			direction = 1;
		}
		else if(Input.GetAxis("(P1) Horizontal") < 0) 
		{
			direction = -1;
		}
		else
		{
			direction = 0;
		}

		if(Input.GetAxis("(P1) HorizontalJoy") != 0)
		{
			direction = Input.GetAxis("(P1) HorizontalJoy");
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

		//check de bloc de glace
		RaycastHit2D hit;
		Vector2 source = new Vector2 (renderer.bounds.center.x, renderer.bounds.center.y - renderer.bounds.extents.y);
		Vector2 dest = -Vector2.up;

		Debug.DrawRay (source, dest, Color.green);
		int mask = 1 << 9;
		hit = Physics2D.Raycast (source, dest, 0.3f,mask);

		if( hit != null && hit.collider != null)
		{
			Debug.Log (hit.collider.gameObject.name);
			if(hit.collider.gameObject.name =="IceBloc" || hit.collider.gameObject.name =="IceTriangle" )
			{
				onIce = true;
			}
			else if(hit.collider.gameObject.name =="PicsBloc" || hit.collider.gameObject.name =="PicsTriangle" )
			{
				Death();
			}
			else if(hit.collider.gameObject.name =="ElectricBloc" || hit.collider.gameObject.name =="ElectricTriangle" )
			{
				Death();
			}
			else if(hit.collider.gameObject.name =="FallingBloc" || hit.collider.gameObject.name =="FallingTriangle" )
			{
				hit.collider.gameObject.GetComponent<FallingBloc>().ReadyToFall();
			}
			else
			{
				onIce = false;
			}

		}
		else
		{
			onIce = false;
		}
	}

	void OnIceEnter()
	{
		onIce = true;
	}

	void OnIceExit()
	{
		onIce = false;
	}

	void Death()
	{
		dead = true;
		gameObject.GetComponent<CharacterDeath>().OnDeath();
		if (!deathSoundPlayed)
		{
			audio.PlayOneShot (deathSound);
			deathSoundPlayed = true;
		}
	}

	void Disappear()
	{
		Death ();
	}

	public void Revive()
	{
		dead = false;
		_animator.Play( Animator.StringToHash( "Idle" ) );
	}

	void Propulse()
	{
		runSpeed = 14f;
		propulsing = true;
	}

	void FixedUpdate()
	{
		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
		
		if( _controller.isGrounded )
			_velocity.y = 0;

		if(dead)
		{
			normalizedHorizontalSpeed = 0;

			if( _controller.isGrounded )
				_animator.Play( Animator.StringToHash( "Death" ) );
		}
		else if( _right )
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

		if(propulsing)
		{
			if(propulseTimerAcc < propulseTimer)
				propulseTimerAcc += Time.deltaTime;
			else
			{
				Debug.Log ("End Propulse");
				runSpeed = 8f;
				propulseTimerAcc = 0;
				propulsing = false;
			}
		}

		// we can only jump whilst grounded
		if( _controller.isGrounded && _up && !dead)
		{
			_velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
			_animator.Play( Animator.StringToHash( "Jump" ) );
			audio.PlayOneShot(jumpSound);
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

	bool isDeadly(GameObject go){
		bool isDeadly = false;


		// Apple SSL Style :D
		if (isDeadly = go.tag == "Enemy")
			goto Dead;
		
		if (isDeadly = go.name == "ElectricBloc")
			goto Dead;

		if (isDeadly = go.name == "ElectricTriangle")
			goto Dead;

//		if (isDeadly = go.name == "PicsBloc")
//			goto Dead;
//
//		if (isDeadly = go.name == "PicsTriangle")
//			goto Dead;

		if (isDeadly = go.name == "Void")
			goto Dead;

		Dead:
		return isDeadly;
	}

}
