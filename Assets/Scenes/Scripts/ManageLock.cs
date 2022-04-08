using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLock : MonoBehaviour
{
    // Identify Object(s)
    public GameObject doorLock;
    // Set timer
    public float activationTime = 3.0f;
    public float deactivationTime = 1.0f;
    // Sound Effect
    [SerializeField]
    private AudioClip doorLockSFX;
    private AudioSource audioSource;


    void Start()
    {
        StartCoroutine(blockWave());
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = doorLockSFX;
    }

    private void activatePlatform()
    {

        // Unlock Door
        if (!doorLock.activeSelf)
        {
            doorLock.SetActive(true);
        }
    }

    private void deactivatePlatform()
    {
        // Lock Door
        if (doorLock.activeSelf)
        {
            doorLock.SetActive(false);
            // Play SFX
            audioSource.Play();
        }
    }

    IEnumerator blockWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(deactivationTime);
            deactivatePlatform();

            yield return new WaitForSeconds(activationTime);
            activatePlatform();
            
        }
    }
}
