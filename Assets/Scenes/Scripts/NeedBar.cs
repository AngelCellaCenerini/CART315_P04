using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// source code: https://youtu.be/UCAo-uyb94c

public class NeedBar : MonoBehaviour
{
    private Slider slider;
    public float emptySpeed = - 0.05f;
    public float fillSpeed = 0.05f;
    private float targetProgress = 0;
    private float targetProgressComplete = 1;
    // public GameObject FinalScene;
    // public GameObject Spawining;

    public Interact bS;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageProgress(1.0f);

        if (bS.isInteracting) 
            {
            if (slider.value < targetProgressComplete)
                {
                    slider.value += fillSpeed * Time.deltaTime;
                }
                   
            }
            else if(!bS.isInteracting)
            {
            if (slider.value < targetProgress)
                {
                    slider.value += emptySpeed * Time.deltaTime;
                }
            }
        }

    public void ManageProgress(float newProgress)
    {
        if (bS.isInteracting)
        {
            targetProgressComplete = slider.value + newProgress;
            
        }
        else if(!bS.isInteracting)
        {
            targetProgress = slider.value + newProgress;
        }
        
    }
}
