using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingTarget : TargetController
{
    public bool isHit = false;

    public TrainingGroundsController controller;

    public override void HitBy(float x)
    {
        if(!isHit){
            controller.TargetShot();
        }

        isHit = true;
        base.HitBy(x);
    }

    public void Reset(){
        isHit = false;
        Stand();
    }
}
