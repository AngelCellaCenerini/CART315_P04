using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote1 : MonoBehaviour
{
    public GameObject noteCloseUp;
    //public GameObject otherNoteCloseUp;
    // public GameObject instructions;
    public GameObject note;
   // public GameObject otherNote;
    public float MaxDistance = 5;
    public Transform PlayerCamera;

    // Bools
    public bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);

        // Player is near Note
        if (distance < MaxDistance)
        {
            Debug.Log("woop");
            //Debug.Log(distance);
            // Player is pressing "E" 
            if (Input.GetKey(KeyCode.E))
            {
                if (note.activeSelf)
                {
                    note.SetActive(false);
                    // instructions.SetActive(false);
                    noteCloseUp.SetActive(true);
                    isOpened = true;

                    // Avoid activating other note
                    //otherNote.SetActive(false);
                    //otherNoteCloseUp.SetActive(false);
                }
                
            }
        }
        else if (distance > MaxDistance)
        {
           
            

            // Note closes automatically
            if (isOpened)
            {
                note.SetActive(true);
                // instructions.SetActive(true);
                noteCloseUp.SetActive(false);
                isOpened = false;
            }
        }


    }


    /*private void OpenNote()
    {
        //float distance = Vector3.Distance(PlayerCamera.transform.position, this.transform.position);

        // Open Note
        //if (distance < MaxDistance)
        //{
            if (note.activeSelf && instructions.activeSelf && !noteCloseUp.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("open");
                    note.SetActive(false);
                    instructions.SetActive(false);
                    noteCloseUp.SetActive(true);
                    isOpened = true;

                    CloseNote();
                }

            }
        //}
    }

    private void CloseNote()
    {
        // Close Note
        if (isOpened)
        {
            if (Input.GetKeyDown(KeyCode.R) && !note.activeSelf && !instructions.activeSelf && noteCloseUp.activeSelf)
            {

                Debug.Log("closed");
                note.SetActive(true);
                instructions.SetActive(true);
                noteCloseUp.SetActive(false);

                isOpened = false;
            }

        }
    }*/



}
