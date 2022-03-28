using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source code: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#trigger_action

public class ResetWall : MonoBehaviour
{
    public float timeRemaining = 4;
    public bool timerIsRunning = false;

    // Objects
    public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        if (wall.activeSelf)
        {
            timerIsRunning = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                wall.SetActive(false);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
