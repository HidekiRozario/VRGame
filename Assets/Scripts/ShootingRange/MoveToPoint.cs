using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    Transform objectT;

    public float speed = 1f;

    public Transform start;
    public Transform end;

    Transform startPoint;
    Transform endPoint;

    bool canMove = true;

    TargetController tc;

    void Start()
    {
        objectT = GetComponent<Transform>();
        startPoint = start.transform;
        endPoint = end.transform;
        tc = GetComponent<TargetController>();
    }

    void Update()
    {
        canMove = tc.isStanding;

        if(canMove){
        float dist = Vector3.Distance(end.position, gameObject.transform.position);

        if(objectT.position == endPoint.position){
            Transform pepePoint = endPoint;
            endPoint = startPoint;
            startPoint = pepePoint;
        }

        objectT.position = Vector3.MoveTowards(objectT.position, endPoint.position, speed * Time.deltaTime);
        }
    }
}
