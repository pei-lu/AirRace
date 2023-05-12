using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class timmer : MonoBehaviour
{
    [SerializeField] public float time;
    [SerializeField] public Boolean activited;
    [SerializeField] public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( activited)
        {
            time += Time.deltaTime;
        }
        DisplayTime(time);
    }

    void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float second = Mathf.FloorToInt(time % 60);
        
        timeText.text = string.Format("{0:00}:{1:00}", minutes, second);
    }

    void FreezeTimmer()
    {

    }

    public void startTimmer() { 
        activited = !activited;
    }
    public void countDownTimmer()
    {
        //count down 3 second activited = true;
    }
}
