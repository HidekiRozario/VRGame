using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float time = 2f;
    void Start()
    {
        Destroy(this.gameObject, time);
    }
}
