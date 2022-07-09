using System;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

public class NetworkMovementScript : NetworkBehaviour
{

	private Rigidbody2D _mRigidbody2D;
	private BoxCollider2D _mBoxCollider;
	private Vector3 _velocity = Vector3.zero;
	private bool _grounded = true;
	private float _horizontalMovement;
	private bool _jump;

	[SerializeField] private float movementSpeed = 50f;
	[SerializeField] private float jumpForce = 500f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl;

	[SerializeField] private LayerMask groundLayer;
	
	private void Start()
	{
		_mRigidbody2D = GetComponent<Rigidbody2D>();
		_mBoxCollider = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		_horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
		_jump = Input.GetAxisRaw("Vertical") > 0;
	}

	private void FixedUpdate()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		CheckForGround();
		
		Move(_horizontalMovement * Time.fixedDeltaTime, _jump);
	}

	private void Move(float move, bool jump)
	{
		//only control the player if grounded or airControl is turned on
		if (_grounded || airControl)
		{
			// Move the character by finding the target velocity
			var currentVelocity = _mRigidbody2D.velocity;

			Vector3 targetVelocity = new Vector2(move * 10f, currentVelocity.y);
			// And then smoothing it out and applying it to the character
			_mRigidbody2D.velocity =
				Vector3.SmoothDamp(currentVelocity, targetVelocity, ref _velocity, movementSmoothing);
		}

		// If the player should jump...
		if (_grounded && jump)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_mRigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}
	}
	
	// ReSharper disable Unity.PerformanceAnalysis
	private void CheckForGround()
	{
		// Cast a ray straight down.
		var rayDown = Physics2D.Raycast(transform.position, Vector2.down, Single.PositiveInfinity, groundLayer.value);

		var distanceToGround = _mBoxCollider.size.y;
		
		_grounded = rayDown.distance <= (0f + distanceToGround);
	}
}