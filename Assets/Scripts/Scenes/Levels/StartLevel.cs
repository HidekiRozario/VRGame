using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    public bool started = false;

    void OnTriggerExit(Collider coll){
        if(coll.tag == "Player"){
            started = true;
        }
    }
}
