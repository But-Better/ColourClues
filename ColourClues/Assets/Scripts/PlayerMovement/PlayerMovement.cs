using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpPower = 5.0f;

    public GameObject[] ladders;
    private string[] ladderNames; 
    
    private Rigidbody2D _playerRigidbody;

    private bool moveUp = false;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        if (_playerRigidbody == null)
        {
            Debug.LogError("Player is missing a Rigidbody2D component");
        }

        ladderNames = new string[ladders.Length];

        for (int i = 0; i < ladderNames.Length; ++i) 
        {
            ladderNames[i] = ladders[i].name;
        }

    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetButton("Jump"))
            Jump();
    }
    private void MovePlayer()
    {
        if(moveUp){
            var verticalInput = Input.GetAxisRaw("Vertical");
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x,verticalInput * playerSpeed);
        }

        var horizontalInput = Input.GetAxisRaw("Horizontal");
        _playerRigidbody.velocity = new Vector2(horizontalInput * playerSpeed, _playerRigidbody.velocity.y);
    }
    private void Jump() => _playerRigidbody.velocity = new Vector2( 0, jumpPower);

    private bool IsGrounded()
    {
        var groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 0.7f);
        return groundCheck.collider != null && groundCheck.collider.CompareTag("Ground");
    }

    private void OnTriggerEnter2D(Collider2D col){

        Debug.Log("Trigger Entered");
        if(ladderNames.Contains(col.name)){
            moveUp = true;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D col){

        Debug.Log("Trigger Exited");
        if(ladderNames.Contains(col.name)){
            moveUp = false;
        }
        
        
    }

   
}