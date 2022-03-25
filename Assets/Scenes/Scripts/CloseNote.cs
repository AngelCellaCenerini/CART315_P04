using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNote : MonoBehaviour
{
    public GameObject noteCloseUp;
    public GameObject instructions;
    public GameObject note;
    public float MaxDistance = 3;
    public Transform PlayerCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //if (distance > 5 * MaxDistance)
            //{
                if (!note.activeSelf && !instructions.activeSelf && noteCloseUp.activeSelf)
                {
                    note.SetActive(true);
                    instructions.SetActive(true);
                    noteCloseUp.SetActive(false);
                }

            }
        //}

        if (distance > 3*MaxDistance)
        {
            note.SetActive(true);
            instructions.SetActive(true);
            noteCloseUp.SetActive(false);
        }
    }

        }
