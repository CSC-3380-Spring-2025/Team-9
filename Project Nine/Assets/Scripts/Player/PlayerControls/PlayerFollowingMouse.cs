using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowingMouse : MonoBehaviour
{


    void Update()
    {

        // Gets position of where the mouse is to the character
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        // Calculates where the relative position of the mouse is to the character
        Vector2 mouseDistance = mousePos - screenPos;
        float angle = Mathf.Atan2(mouseDistance.y, mouseDistance.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
