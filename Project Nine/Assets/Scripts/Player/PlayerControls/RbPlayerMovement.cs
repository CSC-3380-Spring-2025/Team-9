using System;
using UnityEngine;

public class RbPlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 3f;
    private Vector2 PlayerDirection;
    private Vector2 PlayerMovement;


    [HideInInspector] public bool isMoving = false;

    private Rigidbody2D PlayerRb;
    
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        SetPlayerMovementInput();
    }

    private void SetPlayerMovementInput()
    {
        PlayerDirection.x = Input.GetAxisRaw("Horizontal");
        PlayerDirection.y = Input.GetAxisRaw("Vertical");

        if (PlayerDirection.x != 0 || PlayerDirection.y != 0) { isMoving = true; }
        else { isMoving = false; Debug.Log("No Direction Vector: likeley not registering inputs"); }

        PlayerMovement = PlayerDirection.normalized * MoveSpeed;

        PlayerRb.linearVelocity = PlayerMovement;
    }
}
