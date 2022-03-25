using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public GameObject noteCloseUp;
    public GameObject instructions;
    public GameObject note;
    public float MaxDistance = 5;
    public Transform PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);

        if (distance < MaxDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (note.activeSelf && instructions.activeSelf && !noteCloseUp.activeSelf)
                {
                    note.SetActive(false);
                    instructions.SetActive(false);
                    noteCloseUp.SetActive(true);
                }

            }
            /*if (noteCloseUp.activeSelf)
            {
                Debug.Log("bruh");
                if (distance > MaxDistance)
                {
                    Debug.Log("brah");
                    note.SetActive(true);
                    instructions.SetActive(true);
                    noteCloseUp.SetActive(false);
                }
            }*/
        }
    }

}
