using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRoomDoor : MonoBehaviour
{
    
    int openedHash;
    // Declare Objects
    Animator animator;
    public GameObject instructions;
    public GameObject doorLock;

    // Measure distance
    public Transform PlayerCamera;
    public float MaxDistance = 8;

    // Bools
    public bool doorIsOpened = false;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        openedHash = Animator.StringToHash("isOpen");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check PLayer Input
        bool opened = animator.GetBool(openedHash);
        bool openDoor = Input.GetKey("r");

        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);


        if(distance < MaxDistance)
        {
            // Check if lock is active
            if (!doorLock.activeSelf)
            {
                // Display Intructions
                if (!openDoor)
                {
                    // Display Instructions
                    instructions.SetActive(true);
                }
                // Player is pressing "R" 
                if (openDoor)
                {
                    animator.SetBool(openedHash, true);
                    doorIsOpened = true;
                    // Deactivate Instructions
                    if (instructions.activeSelf)
                    {
                        instructions.SetActive(false);
                    }

                }
            }
            else
            {
                // Deactivate Instructions
                if (instructions.activeSelf)
                {
                    instructions.SetActive(false);
                }
                // Keep Door deactivated
                doorIsOpened = false;
            }
        }

        if (distance > MaxDistance)
        // Player walks away from door
        {
            // Deactivate Instructions
            if (instructions.activeSelf)
            {
                instructions.SetActive(false);
            }

            // Door closes automatically
            if (opened)
            {
                animator.SetBool(openedHash, false);
                doorIsOpened = false;
                // Deactivate Instructions
                if (instructions.activeSelf)
                {
                    instructions.SetActive(false);
                }
            }
        }

        if (doorLock.activeSelf)
        // Lock locks Door
        {

            // Door closes automatically
            if (opened)
            {
                animator.SetBool(openedHash, false);
                doorIsOpened = false;
                // Deactivate Instructions
                if (instructions.activeSelf)
                {
                    instructions.SetActive(false);
                }
            }
        }

        // Check if Door is Open
        if (doorIsOpened)
        {
            // Deactivate Instructions
            if (instructions.activeSelf)
            {
                instructions.SetActive(false);
            }
        }
    }
}
