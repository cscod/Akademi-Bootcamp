using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Camera camera;
    Vector2 initialPosition;
    GameObject[] boxArray;

    PuzzleManager manager;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        initialPosition = transform.position;
        boxArray = GameObject.FindGameObjectsWithTag("kutu");
        manager = GameObject.Find("GameManager").GetComponent<PuzzleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject box in boxArray)
            {
                if (box.name == gameObject.name)
                {
                    float distance = Vector3.Distance(box.transform.position, transform.position);

                    if(distance <= 1 )
                    {
                        transform.position = box.transform.position;
                        manager.IncreaseCounter();
                        Destroy(this);
                    }
                    else
                    {
                        transform.position = initialPosition;
                    }
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        Vector3 pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;  
    }
}
