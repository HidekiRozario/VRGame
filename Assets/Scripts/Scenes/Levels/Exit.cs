using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public bool finished = false;
    public LevelController controller;

    public Text timeText;
    public GameObject exitUI;

    void Update(){
        if(controller.levelFinished){
            exitUI.SetActive(true);
            timeText.text = controller.timeOnHand.text;
        }
    }

    void OnTriggerEnter(Collider coll){
        if(coll.tag == "Player"){
            finished = true;
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.tag == "Player"){
            finished = false;
        }
    }
}
