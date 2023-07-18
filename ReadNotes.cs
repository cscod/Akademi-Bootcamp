using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReadNotes : MonoBehaviour
{
    public GameObject noteUI;

    public GameObject pickUpText;

    public AudioSource pickUpSound;

    public bool inCollider;


    void Start()
    {
        noteUI.SetActive(false);
        pickUpText.SetActive(false);

        inCollider = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Remy")
        {
            inCollider = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Remy")
        {
            inCollider = false;
            pickUpText.SetActive(false);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inCollider)
        {
            noteUI.SetActive(true);
            pickUpText.SetActive(false);
            pickUpSound.Play();
        }
    }

    public void ExitButton()
    {
        noteUI.SetActive(false);
        if (inCollider)
        {
            pickUpText.SetActive(true);
        }
    }
}
