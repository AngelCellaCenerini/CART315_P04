using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator animator;
    int openedHash;
    // To measure distance
    public Transform PlayerCamera;
    public float MaxDistance = 5;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        openedHash = Animator.StringToHash("Opened");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check PLayer Input
        //bool opened = animator.GetBool("Opened");
        bool opened = animator.GetBool(openedHash);
        bool openDoor = Input.GetKeyDown("r");
        bool closeDoor = Input.GetKeyUp("r");

        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);


        if(distance < MaxDistance)
        {
            // Player is pressing "F" 
            if (openDoor)
            {
                animator.SetBool(openedHash, true);
            }
            // Player is not pressing "F"
            /* if (closeDoor && opened)
            {
                animator.SetBool(openedHash, false);
            }*/
        }
        if (distance > MaxDistance)
        {
            // Player is not pressing "F"
            if (opened)
            {
                animator.SetBool(openedHash, false);
            }
        }
       
    }
        }
