using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionResponse : MonoBehaviour
{
    // Declare Objects
    public GameObject block;
    public GameObject player;
    public GameObject blankRoom;
    //[SerializeField] Transform spawnPoint;
    public Transform spawnPoint;
    public bool teleported = false;
    // Wall's class
    public ResetWall bS;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            //this.transform.position = spawnPoint.position;
            HitPlayer();
        }
    }

    void HitPlayer()
    {
        // Call/identify PlayerCapsule's Character Controller
        CharacterController cc = player.GetComponent<CharacterController>();
        // Disable PlayerCapsule's Character Controller
        cc.enabled = false;
        // Move PlayerCapsule
        player.transform.position = spawnPoint.transform.position;
        // Re-enable PlayerCapsule's Character Controller
        cc.enabled = true;

        // Activate Block Wall
        blankRoom.SetActive(true);
    }

    
}
