using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DisplayTime : MonoBehaviour
{
    public GameObject TheDisplay;
    string hour;
    string minutes;

    // Update is called once per frame
    void Update()
    {

        hour = System.DateTime.Now.Hour.ToString();
        minutes = System.DateTime.Now.Minute.ToString();
        if (hour.Length == 1)
        {
            hour = "0" + hour;
        }
        if (minutes.Length == 1)
        {
            minutes = "0" + minutes;
        }
        TheDisplay.GetComponent<TextMeshProUGUI>().text = "" + hour + ":" + minutes;
    }
}
