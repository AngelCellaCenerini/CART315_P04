using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : MonoBehaviour
{
    Animator animator;
    int isTypingHash;
    // To measure distance
    public Transform PlayerCamera;
    public GameObject keyboard;
    public float MaxDistance = 5;
    // Activate Spawning
    public GameObject spawningMechanic;
    // Typing SFX
    public AudioSource typeSFX;

    public bool typing = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isTypingHash = Animator.StringToHash("isTyping");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check PLayer Input
        bool isTyping = animator.GetBool(isTypingHash);
        bool fPressed = Input.GetKey("f");
        float distance = Vector3.Distance(PlayerCamera.transform.position, keyboard.transform.position);

        // Idle > Typing Transition
        // Check distance
        // Player is pressing "F" 
        if (distance < MaxDistance)
        {
            if (!isTyping && fPressed)
            {
                animator.SetBool(isTypingHash, true);
                spawningMechanic.SetActive(true);
                typing = true;

                //SFX
                if (!typeSFX.isPlaying)
                {
                    typeSFX.Play();
                }
            }
            // Player is not pressing "F"
            if (isTyping && !fPressed)
            {
                animator.SetBool(isTypingHash, false);
                typeSFX.Stop();
                typing = false;
            }
        }
        else
        {
            // Player is not near keyboard
            animator.SetBool(isTypingHash, false);
            typing = false;
        }
    }
}
