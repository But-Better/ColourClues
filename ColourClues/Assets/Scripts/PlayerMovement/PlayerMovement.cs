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

        ladderNames = new string[ladders.Length];

        for (int i = 0; i < ladderNames.Length; ++i) 
        {
            ladderNames[i] = ladders[i].name;
        }

    }
    
    private void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (moveUp)
        {
            var verticalInput = Input.GetAxisRaw("Vertical");
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, verticalInput * playerSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){

        Debug.Log("Trigger Entered");
        if(ladderNames.Contains(col.name)){
            moveUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col){

        Debug.Log("Trigger Exited");
        if (ladderNames.Contains(col.name))
        {
            moveUp = false;
        }
    }
}