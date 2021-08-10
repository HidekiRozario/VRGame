using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRayRotation : MonoBehaviour
{
    GameObject leftRay;
    GameObject rightRay;

    // Start is called before the first frame update
    void Start()
    {
        leftRay = GameObject.Find("[RayInteractorLeft] Original Attach");
        rightRay = GameObject.Find("[RayInteractorRight] Original Attach");
        leftRay.transform.Rotate(new Vector3(62f, 0, 0));
        rightRay.transform.Rotate(new Vector3(62f, 0, 0));
    }
}