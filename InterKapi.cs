using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class InterKapi : MonoBehaviour
{
    public float radius = 3f;
    Transform player;

    public Camera objectCam; //ObjeyigösterecekCamera
    public Camera remyCam; //PlayerCamera

    public TextMeshProUGUI canvasText;
    public GameObject epanel;
    private bool isFocus = false;
    //Object special variables
    private bool haveKey = true;
    //public denemelock lockscript;
    public GameObject toka;
    public static bool tellme = false;
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireCube(transform.position, transform.lossyScale * 1f);
        //transform.localScale).magnitude * 10

    }

    private void Start()
    {
        player = GameObject.Find("Remy").transform;

        objectCam.enabled = false;
        canvasText.gameObject.SetActive(false);
        epanel.SetActive(false);
        toka.SetActive(false);
    }


    private void OnMouseOver() //Mouse objenin üstüne geldiðinde ismi gözüksün.
    {
        if(this.enabled)
        {
            if (remyCam.enabled)
            {
                //canvas.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(true);
                canvasText.gameObject.SetActive(true);
                Debug.Log("qwýehyqýwuheqwe");
            }
        }
        
    }

    private void OnMouseExit()
    {
        if (this.enabled)
        {
            canvasText.gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position); //Obje ile player arasýndaki mesafe
        //Debug.Log(distance);
        if (distance < 7) //Player objenin çevresindeki belirli bir alana girdiðinde:
        {
            epanel.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.E)) //Objeye odaklanmak için E'ye bas.
            {
                //player.GetComponent<NavMeshAgent>().isStopped = true; //Player E'ye bastýðýnda yürümeyi durdursun.
                player.GetComponent<NavMeshAgent>().destination = player.transform.position;

                objectCam.enabled = true;
                remyCam.enabled = false;
                isFocus = true;
                epanel.GetComponentInChildren<TextMeshProUGUI>().text = "To exit press: ESC";
            }

            if (Input.GetKeyDown(KeyCode.Escape)) //Main screen'e dönmek için  esc'ye bas.
            {
                objectCam.enabled = false;
                remyCam.enabled = true;
                Debug.Log("x");
                isFocus = false;
                if (toka.IsDestroyed() == false)
                {
                    toka.SetActive(false);
                }
                
                epanel.GetComponentInChildren<TextMeshProUGUI>().text = "To interact press: E";
                player.GetComponent<NavMeshAgent>().isStopped = false;
            }

            if (isFocus)
            {
                if (haveKey)
                {
                    if(toka != null)
                    {
                        toka.SetActive(true);
                    }
                } else {
                    epanel.GetComponentInChildren<TextMeshProUGUI>().text = "You need something to open\nTo exit press: ESC";
                }
            }
            
        }
        else
        {
            epanel.SetActive(false);
            
        }
        if(tellme)
        {
           // gameObject.GetComponent<NavMeshObstacle>().enabled = false;
            gameObject.GetComponent<InterKapi>().enabled = false;
            epanel.SetActive(false);
        }
    }
}
