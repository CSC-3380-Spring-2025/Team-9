using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    bool timerRunning = false;
    private Vector3 lastPosition;

    //Initializes player location. Used as referance for timer start.
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame. Starts timer on player movement.
    void Update()
    {
        if(!timerRunning && HasMoved())
        {
                timerRunning = true;
        }
        if(timerRunning)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
        
    }
    //Checks for player movement.
    private bool HasMoved()
    {
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
    }
}
