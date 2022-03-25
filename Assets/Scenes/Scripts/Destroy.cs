using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source code: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#trigger_action

public class Destroy : MonoBehaviour
{
    public float timeRemaining = 4;
    public bool timerIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
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
                Destroy(this.gameObject);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
