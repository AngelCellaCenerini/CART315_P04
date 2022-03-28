using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlatforms : MonoBehaviour
{
    // Identify Object(s)
    public GameObject upperPlatform;
    public GameObject lowerPlatform;
    // Set timer
    public float activationTime = 3.0f;
    public float deactivationTime = 1.0f;
    // Sound Effect
    [SerializeField]
    private AudioClip platformSFX;
    private AudioSource audioSource;


    void Start()
    {
        StartCoroutine(blockWave());
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = platformSFX;
    }

    private void activatePlatform()
    {

        // Upper Platform
        if (!upperPlatform.activeSelf)
        {
            upperPlatform.SetActive(true);
            audioSource.Play();

        }

        // Lower Platform
        if (!lowerPlatform.activeSelf)
        {
            lowerPlatform.SetActive(true);
            audioSource.Play();
        }
    }

    private void deactivatePlatform()
    {
        // Upper Platform
        if (upperPlatform.activeSelf)
        {
            upperPlatform.SetActive(false);
        }

        // Lower Platform
        if (lowerPlatform.activeSelf)
        {
            lowerPlatform.SetActive(false);
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
