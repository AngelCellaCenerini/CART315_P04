using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    // Declare Materials
    public Material originalMaterial;
    public Material temporaryMaterial;
    // Declare Objects
    public GameObject targetObject;
    public GameObject bottleLabel;
    public float MaxDistance = 5;
    public Transform PlayerCamera;
    // Declare Bools
    public bool isGlowing;
    public bool isInteracting;
    public bool isBottle;

    // Start is called before the first frame update
    void Start()
    {
        isGlowing = true;
        isInteracting = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Calculate distance between Object and PlayerCapsule
        float distance = Vector3.Distance(PlayerCamera.transform.position, targetObject.transform.position);

        // Check distance between Object and PlayerCapsule
        if (distance < MaxDistance)
        {
            if (isGlowing)
            {
                // Change Material to Glowly one
                targetObject.GetComponent<MeshRenderer>().material = temporaryMaterial;
                // For Bottle Object
                if (isBottle)
                {
                    bottleLabel.SetActive(false);
                }
            }

            // Check keyboard Input
            if (Input.GetKey(KeyCode.E))
            {
                // Change Material to Original one
                targetObject.GetComponent<MeshRenderer>().material = originalMaterial;
                // De-activate Glowing
                isGlowing = false;
                // For Bottle Object
                if (isBottle)
                {
                    bottleLabel.SetActive(false);
                    targetObject.SetActive(false);
                }
                // Track Interaction
                isInteracting = true;
            }
            else{
                // Track Interaction
                isInteracting = false;
                // For Bottle Object
                if (isBottle && !isGlowing)
                {
                    bottleLabel.SetActive(true);
                    targetObject.SetActive(true);
                }
            }
        }
        else
        {
            // Change Material to Original one
            targetObject.GetComponent<MeshRenderer>().material = originalMaterial;
            // For Bottle Object
            if (isBottle)
            {
                bottleLabel.SetActive(true);
            }
            // Reset Glowing 
            isGlowing = true;
        }
    }
}
