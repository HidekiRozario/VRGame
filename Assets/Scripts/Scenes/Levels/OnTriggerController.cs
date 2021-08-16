using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerController : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    void OnTriggerEnter(Collider coll){
        if(coll.gameObject.tag == "Player"){
            OnEnter.Invoke();
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.gameObject.tag == "Player"){
            OnExit.Invoke();
        }
    }

}
