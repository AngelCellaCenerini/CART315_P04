using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source code: https://youtu.be/E7gmylDS1C4

public class Delay : MonoBehaviour
{
    // Set Timer
    public float replayTime = 3.0f;
    // Sound Effect
    [SerializeField]
    private AudioClip whereNC;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blockWave());
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whereNC;
    }
    private void playSound()
    {
        audioSource.Play();
    }

    IEnumerator blockWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(replayTime);
            playSound();
        }
    }
}
