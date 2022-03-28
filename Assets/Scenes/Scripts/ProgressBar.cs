using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// source code: https://youtu.be/UCAo-uyb94c

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float fillSpeed = 0.05f;
    private float targetProgress = 0;
    public GameObject FinalScene;
    public GameObject Spawining;
    public GameObject seats;

    public Type bS;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        IncrementProgress(1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (slider.value < targetProgress)
            {
                if (bS.typing)
                {
                    slider.value += fillSpeed * Time.deltaTime;
                }
            }
            else
            {
                // Debug.Log("complete");
                // Activate "Final Fan" and Golden Lighting & Deactivate Obstacles
                FinalScene.SetActive(true);
                Spawining.SetActive(false);
            }

        CheckPreogress();

    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void CheckPreogress()
    {
        if (slider.value > 0.7f)
        {
            seats.SetActive(true);
        }
    }
}
