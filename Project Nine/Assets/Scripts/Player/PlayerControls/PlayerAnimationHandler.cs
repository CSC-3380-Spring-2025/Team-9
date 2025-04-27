using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator playerAnimator;
    private Vector3 prevPosition;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        prevPosition = transform.position;
    }
    void Update()
    {
        //mouse position for direction of animation
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y).normalized;

        playerAnimator.SetFloat("MouseX", lookDir.x);
        playerAnimator.SetFloat("MouseY", lookDir.y);

        //player speed for walk animations
        /*
        float distanceMoved = Vector3.Distance(transform.position, prevPosition);
        float speed = distanceMoved / Time.deltaTime;

        playerAnimator.SetFloat("Velocity", speed);
        Debug.Log(speed);

        prevPosition = transform.position;
        */
    }
}
