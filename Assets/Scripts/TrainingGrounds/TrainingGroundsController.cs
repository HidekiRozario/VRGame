using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingGroundsController : MonoBehaviour
{
    public int numOfTargets;
    public int targetsLeft;

    public bool canStop = false;

    public List<TrainingTarget> targets = new List<TrainingTarget>();

    void Start(){
        targetsLeft = targets.Count;
        numOfTargets = targets.Count;
    }

    void Update(){
        if(targetsLeft <= 0){
            canStop = true;
        }
        if(targetsLeft > 0){
            canStop = false;
        }
    }

    public void TargetShot(){
        targetsLeft--;
    }

    public void EndTraining(){
        if(targetsLeft <= 0){
            foreach(TrainingTarget target in targets){
                target.Reset();
            }
            targetsLeft = targets.Count;
            numOfTargets = targets.Count;
        }
    }

    public void ResetTraining(){
        foreach(TrainingTarget target in targets){
            if(!target.isStanding)
            target.Reset();
        }
        targetsLeft = targets.Count;
        numOfTargets = targets.Count;
    }
}
