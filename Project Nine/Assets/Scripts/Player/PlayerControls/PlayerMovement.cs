using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    
    public float MoveSpeed = 5f;
    public float RollSpeed = 8f;
    public float RollDuration = 0.5f;
    public Rigidbody2D Rb;
    public LayerMask WallLayer;


    private Vector2 _movement;
    private bool _isRolling = false;
    private Vector2 _lastMoveDirection;

    void Update()
    {
        if (!_isRolling)
        {
            HandleMovementInput();
            MovePlayer();
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
            //MovePlayer();
        }
    }

    private void HandleMovementInput()
    {
        _movement.x = Input.GetAxisRaw("Horizontal"); // gets the horizontal input
        _movement.y = Input.GetAxisRaw("Vertical"); // gets the vertical input
        
        Vector2 wallPosition = Rb.position + _lastMoveDirection.normalized; 
        if (_movement.magnitude > 1 && !IsTouchingWall(Rb.position, wallPosition)) // for when the player goes top left, top right, bottom left, bottom right at the same time
        {
            // the vector is not normalized when touching a wall, thus allowing for 'frictionless' movement.
            _movement = _movement.normalized; 
        }
    }

    private void MovePlayer()
    {
        //Rb.MovePosition(Rb.position + _movement * MoveSpeed * Time.fixedDeltaTime); // moves the player
        Vector2 targetPosition = Rb.position + _movement * MoveSpeed * Time.fixedDeltaTime;

        if (!IsTouchingWall(Rb.position, targetPosition))
        {
            Rb.MovePosition(targetPosition); // only move if not touching wall
        }

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


        Vector2 immCheck = Rb.position + rollDirection.normalized * 2f;  // check infront of where player is moving if roll would go thru a wall
        if (IsTouchingWall(Rb.position, immCheck))
        {
            _isRolling = false;
            yield break;
        }
    
        Rb.linearVelocity = rollDirection.normalized * RollSpeed;
        yield return new WaitForSeconds(RollDuration);

        Rb.linearVelocity = Vector2.zero;
        _isRolling = false;
    }


   private bool IsTouchingWall(Vector2 startPosition, Vector2 targetPosition)
    {
  
        float checkDistance = Vector2.Distance(startPosition, targetPosition);
        Vector2 direction = (targetPosition - startPosition).normalized;

        // checks if the player is touching a wall by raycasting
        RaycastHit2D hit = Physics2D.Raycast(startPosition, direction, checkDistance, WallLayer);
        return hit.collider != null;
    }
}
