using System;
using System.Linq;
using Mirror;
using UnityEngine;
using View;

[RequireComponent(typeof(LoadMode))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class NetworkMovementScript : NetworkBehaviour
{

	private LoadMode _mMovementLoader;
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
		_mMovementLoader = GetComponent<LoadMode>();
		_mRigidbody2D = GetComponent<Rigidbody2D>();
		_mBoxCollider = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		// ReSharper disable once Unity.PerformanceCriticalCodeInvocation
		var movementKeys = _mMovementLoader.GetLoadedData();

		var jumpButtonKey = movementKeys.TextForward;
		var leftButton = movementKeys.TextLeft;
		var rightButton = movementKeys.TextRight;

		_horizontalMovement = 
			((Input.GetKey(leftButton) ? -1 : 0) + (Input.GetKey(rightButton) ? 1 : 0)) 
			* movementSpeed;
		
		_jump = Input.GetKey(jumpButtonKey);
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
		var middlePosition = transform.position;
		var boxColliderWidth = _mBoxCollider.size.x;

		var mostLeft = middlePosition - new Vector3(boxColliderWidth / 2, 0);
		var mostRight = middlePosition + new Vector3(boxColliderWidth / 2, 0);
		
		// Cast a ray straight down.
		var rayMiddleDown = Physics2D.Raycast(middlePosition, Vector2.down, Single.PositiveInfinity, groundLayer.value);
		var rayMostLeftDown = Physics2D.Raycast(mostLeft, Vector2.down, Single.PositiveInfinity, groundLayer.value);
		var rayMostRightDown = Physics2D.Raycast(mostRight, Vector2.down, Single.PositiveInfinity, groundLayer.value);

		var distanceToGround = _mBoxCollider.size.y;


		_grounded = anyRayHasDistanceOf(distanceToGround, rayMiddleDown, rayMostLeftDown, rayMostRightDown);
	}

	private bool anyRayHasDistanceOf(float maxDistance, params RaycastHit2D[] rays)
	{
		return rays.Any(ray => ray.distance <= maxDistance);
	}
}