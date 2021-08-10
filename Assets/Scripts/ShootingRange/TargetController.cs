using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float standCooldown;

    float standTime;
    public bool isStanding = true;

    public bool standable = true;

    Animator targetAnim;

    void Start(){
        targetAnim = GetComponentInChildren<Animator>();
    }

    void Update(){
        if(!isStanding && standable){
            standTime -= Time.deltaTime;
            if(standTime <= 0){
                Stand();
            }
        }
    }

    public void Stand(){
        isStanding = true;
        targetAnim.Play("Stand");
    }

    public virtual void HitBy(float x){
        if(isStanding){
        isStanding = false;
        standTime = standCooldown;
        targetAnim.Play("Fall");
        }
    }
}
