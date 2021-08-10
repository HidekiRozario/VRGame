using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public bool isHit = false;

    void HitBy() => isHit = true;

    void Update(){
        if(isHit)
        Debug.Log(isHit);
    }
}
