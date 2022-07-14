using System;
using System.Linq;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;
using View;

[RequireComponent(typeof(LoadMode))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class NetworkMovementScript : NetworkBehaviour
{

	private Rigidbody2D _mRigidbody2D;
	private Vector3 _velocity = Vector3.zero;
	private bool _grounded = true;
	private float _horizontalMovement;
	private bool _jump;
	private bool _inLadder;
	
	
	[SerializeField] private float movementSpeed = 50f;
	[SerializeField] private float jumpForce = 500f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl; 
	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private LayerMask ladderLayer;
	
	private void Start()
    {
	    _mRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
	    if(!isLocalPlayer) {
		    return;
	    }

	    _horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;
	    _jump = Input.GetAxisRaw("Vertical") > 0;
    }

    private void FixedUpdate()
	{
		if(!isLocalPlayer) {
			return;
		}

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
			_mRigidbody2D.velocity = Vector3.SmoothDamp(currentVelocity, targetVelocity, ref _velocity, movementSmoothing);
		}
		// If the player should jump...
		if (_grounded && jump && !_inLadder)
		{
			// Add a vertical force to the player.
			_grounded = false;
			_mRigidbody2D.AddForce(new Vector2(0f, jumpForce));
		}

		if (_inLadder && jump)
		{
			_mRigidbody2D.velocity = new Vector2(_mRigidbody2D.velocity.x,movementSpeed);
		}
    }

    public void OnTriggerStay2D(Collider2D other)
    {
	    if (other.gameObject.name.Contains("Ladder"))
	    {
		    _inLadder = true;
	    }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
	    if (other.gameObject.name.Contains("Ladder"))
	    {
		    _inLadder = false;
	    }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
	    if (GameObjectIsInLayerMask(other.gameObject, groundLayer))
	    {
		    _grounded = true;
	    }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
	    if (GameObjectIsInLayerMask(other.gameObject, groundLayer))
	    {
		    _grounded = false;
	    }
    }

    private static bool GameObjectIsInLayerMask(GameObject gameObject, int layerMask)
    {
	    return (layerMask == (layerMask | (1 << gameObject.layer)));
    }
}