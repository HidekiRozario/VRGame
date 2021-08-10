using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerOnDisplay : MonoBehaviour
{
    Text timerText;

    bool timeRunning = false;
    float time = 0;

    public TrainingGroundsController controller;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRunning)
        time += Time.deltaTime;

        timerText.text = time.ToString("F2") + " " + controller.targetsLeft + "/" + controller.numOfTargets;
    }

    public void ResetTimer(){
        time = 0;
    }

    public void StartTimer(){
        ResetTimer();
        timeRunning = true;
    }

    public void StopTimer(){
        if(controller.canStop)
        timeRunning = false;
    }
}
