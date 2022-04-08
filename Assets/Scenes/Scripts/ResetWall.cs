using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// source code: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#trigger_action

public class ResetWall : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;

    // Objects
    public GameObject blankRoom;
    public GameObject player;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        if (blankRoom.activeSelf)
        {
            timerIsRunning = true;
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerIsRunning && blankRoom.activeSelf)
        {
            timeRemaining += Time.deltaTime;

            // Mute Volume
            AudioListener.volume = 0f;

            if (timeRemaining > 12f)
            {
                // Teleport PlayerCapsule
                // Call/identify PlayerCapsule's Character Controller
                CharacterController cc = player.GetComponent<CharacterController>();
                // Disable PlayerCapsule's Character Controller
                cc.enabled = false;
                // Move PlayerCapsule
                player.transform.position = spawnPoint.transform.position;
                // Re-enable PlayerCapsule's Character Controller
                cc.enabled = true;

                // Reset Timer & Blank Room
                timeRemaining = 0;
                //timerIsRunning = false;
                blankRoom.SetActive(false);

                // Reset Volume
                AudioListener.volume = 1f;
            }
        }
    }
}
