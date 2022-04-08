using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    
    int openedHash;
    // Declare Objects
    Animator animator;
    public GameObject fridge;
    public GameObject fridgeDoor;
    public GameObject instructions;
    // Declare Materials
    public Material originalMaterial;
    public Material temporaryMaterial;

    // Measure distance
    public Transform PlayerCamera;
    public float MaxDistance = 8;

    // Bools
    //public bool isGlowing = false;
    public bool doorIsOpened = false;
    public bool instructionsOn;



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
        bool opened = animator.GetBool(openedHash);
        bool openDoor = Input.GetKey("r");

        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);


        if(distance < MaxDistance)
        {
            // Change Material to Glow-y one
            //isGlowing = true;
            //Debug.Log("true - distance <");
            if (instructionsOn)
            {
                instructions.SetActive(true);
            }
            


            // Player is pressing "R" 
            if (openDoor)
            {
                animator.SetBool(openedHash, true);
                doorIsOpened = true;
                // Restore Original Material 
                //isGlowing = false;
                //Debug.Log("false - distance < but R"); 
                instructionsOn = false;
                
            }
        }

        if (distance > MaxDistance)
        // Player walks away from fridge
        {
            // Restore Original Material 
            //isGlowing = false;
            //Debug.Log("false - distance >");
            instructionsOn = true;
            instructions.SetActive(false);

            // Fridge Door closes automatically
            if (opened)
            {
                animator.SetBool(openedHash, false);
                doorIsOpened = false;
            }
        }
    }
}
