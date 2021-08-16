using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    public bool isOpened = false;
    public bool doorWithTargets = false;

    public UnityEvent TargetDown;
    public TargetController[] targets;

    Vector3 closedPosition;
    Vector3 openPosition;

    void Start(){
        openPosition = transform.position + new Vector3(0, transform.localScale.y - 0.5f, 0);
        closedPosition = transform.position;
    }

    void FixedUpdate(){
        if(doorWithTargets)
        CheckIfTargetsDown();

        if(isOpened)
        transform.position = Vector3.MoveTowards(transform.position, openPosition, 2f * Time.deltaTime);
        else
        transform.position = Vector3.MoveTowards(transform.position, closedPosition, 2f * Time.deltaTime);
    }

    public void OpenDoors(){
        isOpened = true;
    }

    public void CloseDoors(){
        isOpened = false;
    }

    void CheckIfTargetsDown(){
        bool check = false;
        foreach(TargetController target in targets){
            if(target.isStanding){
                check = false;
                break;
            } else check = true;
        }
        isOpened = check;
    }
}
