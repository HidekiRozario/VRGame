using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStorage : MonoBehaviour
{
    public float time;
    public bool finished = false;
    public string levelName;
    public string levelWorld;

    void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
}
