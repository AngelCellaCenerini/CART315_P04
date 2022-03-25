using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// source code: https://youtu.be/UCAo-uyb94c

public class NeedBar : MonoBehaviour
{
    private Slider slider;
    public float emptySpeed = - 0.05f;
    private float targetProgress = 0;
    // public GameObject FinalScene;
    // public GameObject Spawining;

    // public Type bS;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        DecreaseProgress(1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (slider.value > targetProgress)
            {
                // if (bS.typing)
                // {
                    slider.value += emptySpeed * Time.deltaTime;
                // }
            }
            /* else
            {
                // Debug.Log("complete");
                // Activate "Final Fan" and Golden Lighting & Deactivate Obstacles
                // FinalScene.SetActive(true);
                // Spawining.SetActive(false);
            }*/

    }

    public void DecreaseProgress(float newProgress)
    {
        targetProgress = slider.value - newProgress;
    }
}
