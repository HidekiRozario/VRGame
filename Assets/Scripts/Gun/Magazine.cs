using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Magazine : MonoBehaviour
{
    public int bullets;

    public bool attached = false;

    XRGrabInteractable grabScript;

    void Start(){
        grabScript = GetComponent<XRGrabInteractable>();
    }

    void Update(){
        if(attached){
            grabScript.interactionLayerMask = LayerMask.GetMask("NonGrabable");
        }
        else{
            grabScript.interactionLayerMask = LayerMask.GetMask("Grab Interactible");
        }
        if(bullets <= 0 && !attached){
            Destroy(this.gameObject, 2f);
        }
    }
}
