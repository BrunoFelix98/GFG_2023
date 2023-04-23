using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CounterController : MonoBehaviour
{
    public DateTime currentTime;
    public DateTime startTime;
    public DateTime endTime;
    public float hour;
    public float minute;

    // Start is called before the first frame update
    void Start()
    {
        endTime = new DateTime(2000, 09, 01, 18, 0, 0);
        hour = 9f;
        minute = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < endTime)
        {
            minute += Time.deltaTime * 9;
            if(minute >= 60)
            {
                hour++;
                minute = 0;
            }
            currentTime = new DateTime(2000, 09, 01, (int)hour, (int)minute, 0);
        }
        this.gameObject.GetComponent<TextMeshProUGUI>().text = currentTime.ToString("HH:mm");
    }
}
