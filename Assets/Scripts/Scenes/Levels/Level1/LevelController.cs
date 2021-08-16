using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    float playerTime = 0;
    bool allTargetsDown = false;

    public bool levelFinished = false;
    public string levelName = "Level 1";
    public string levelWorld = "World 1";

    public TargetController[] targets;
    public Exit exit;
    public StartLevel start;
    public TimeStorage container;

    public Text timeOnHand;

    // Update is called once per frame
    void Update()
    {
        if(exit.finished){
            CheckIfLevelFinished();
            if(allTargetsDown){
                //FINISH LEVEL
                levelFinished = true;
                container.time = playerTime;
                container.finished = true;
                container.levelName = levelName;
                container.levelWorld = levelWorld;
            }
        }

        if(start.started && !levelFinished){
            playerTime += Time.deltaTime;
            timeOnHand.text = playerTime.ToString("F2");
        }
    }

    void CheckIfLevelFinished(){
        bool check = false;
        foreach(TargetController target in targets){
            if(target.isStanding){
                check = false;
                break;
            } else check = true;
        }
        allTargetsDown = check;
    }
}
