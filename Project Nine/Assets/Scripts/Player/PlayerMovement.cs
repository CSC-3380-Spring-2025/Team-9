using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    
    public float MoveSpeed = 5f;
    public float RollSpeed = 8f;
    public float RollDuration = 0.5f;
    public Rigidbody2D Rb;


    private Vector2 _movement;
    private bool _isRolling = false;
    private Vector2 _lastMoveDirection;

    void Update()
    {
        if (!_isRolling)
        {
            HandleMovementInput();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isRolling)
        {
            StartCoroutine(Roll());
        }

        if (_movement != Vector2.zero)
        {
            _lastMoveDirection = _movement; // saves last movement direction when the player moves
        }
    }

    void FixedUpdate()
    {
        if (!_isRolling)
        {
            MovePlayer();
        }
    }

    private void HandleMovementInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal"); // gets the horizontal input
        _movement.y = Input.GetAxisRaw("Vertical"); // gets the vertical input
        

        if (_movement.magnitude > 1) // for when the player goes top left, top right, bottom left, bottom right at the same time
        {
            _movement = _movement.normalized; 
        }
    }

    private void MovePlayer()
    {
        Rb.MovePosition(Rb.position + _movement * MoveSpeed * Time.fixedDeltaTime); // moves the player

    }

    private IEnumerator Roll()
    {
        _isRolling = true;

        Vector2 rollDirection = _movement;
        if (rollDirection == Vector2.zero)
        {
            // roll to last player movement direction
            rollDirection = _lastMoveDirection == Vector2.zero ? Vector2.right : _lastMoveDirection;
        }

        Rb.linearVelocity = rollDirection * RollSpeed;

        StartCoroutine(RollPlaceholderAnimation()); // placeholder animation until we get a proper roll animation

        yield return new WaitForSeconds(RollDuration);

        _isRolling = false;
    }


    private IEnumerator RollPlaceholderAnimation() // simple roll animation that rotates the player sprite 180 degrees
    {
        
        //(its not perfect because it overrotates but since this is just a placeholder it should be fine for now)
        
        float elapsedTime = 0f;
        float totalRotation = 180f;
        float rotationSpeed = totalRotation / RollDuration; 

         while (elapsedTime < RollDuration)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime; 
            transform.Rotate(0, 0, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null; 
        }
    }


}
