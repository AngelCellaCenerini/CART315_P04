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
    public bool isPhone;
    // Declare Other Class
    public OpenDoor bS;
    // Sound Effect
    [SerializeField]
    private AudioClip doorLockSFX;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Set Up starting Bools
        isGlowing = true;
        isInteracting = false;
        // Set Up SFX
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = doorLockSFX;
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
                // For Phone Object
                if (isPhone)
                {
                    targetObject.SetActive(false);
                }

                // Track Interaction
                isInteracting = true;
                // Play SFX
                audioSource.Play();
            }
            else{
                // Track Interaction
                //isInteracting = false;
                // For Bottle Object
                /*if (isBottle && !isGlowing)
                {
                    bottleLabel.SetActive(true);
                    targetObject.SetActive(true);
                }*/
                // For Phone Object
                if (isPhone)
                {
                    targetObject.SetActive(true);
                }
            }
        }
        else
        {
            // Track Interaction
            isInteracting = false;
            // Change Material to Original one
            targetObject.GetComponent<MeshRenderer>().material = originalMaterial;
            // For Bottle Object
            if (isBottle)
            {
                // Check Fridge Door
                if (distance >= MaxDistance * 2.8)
                {
                    // Reset Bottle Object
                    targetObject.SetActive(true);
                    bottleLabel.SetActive(true);
                }

            }
            // Reset Glowing 
            isGlowing = true;
        }
    }
}
