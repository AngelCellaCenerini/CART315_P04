using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Identify Objects
    public GameObject player;
    public GameObject platform;
    [SerializeField] Transform teleportPlatform;

    void OnTriggerStay(Collider other)
    {
        // Check if Platform is active/displaying
        if (platform.activeSelf)
        {
            // Check if Player has triggered collision
            if (other.gameObject == player)
            {
                // Call/identify PlayerCapsule's Character Controller
                CharacterController cc = player.GetComponent<CharacterController>();
                // Disable PlayerCapsule's Character Controller
                cc.enabled = false;
                // Move PlayerCapsule
                player.transform.position = teleportPlatform.transform.position;
                // Re-enable PlayerCapsule's Character Controller
                cc.enabled = true;

            }
        }
    }
}
