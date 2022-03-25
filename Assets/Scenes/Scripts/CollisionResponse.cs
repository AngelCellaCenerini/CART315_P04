using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionResponse : MonoBehaviour
{
    public GameObject block;
    public GameObject player;
    //[SerializeField] Transform spawnPoint;
    public Transform spawnPoint;
    public bool teleported = false;

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
        Debug.Log("hittttt");
        //this.GetComponent<Rigidbody>().AddForce(0, 0, 1000);
        player.transform.position = spawnPoint.position;
        Debug.Log(transform.position);
        //fgf
    }
}
