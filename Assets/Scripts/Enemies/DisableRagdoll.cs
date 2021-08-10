using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableRagdoll : MonoBehaviour
{
    public BoxCollider[] colliders;
    public CapsuleCollider[] collidersC;
    public SphereCollider[] collidersS;
    public Rigidbody[] rbs;
    public XRGrabInteractable[] grabInteractables;

    public void TurnRagdoll(bool state){
        foreach(BoxCollider coll in colliders){
            coll.enabled = state;
        }
        foreach(CapsuleCollider coll in collidersC){
            coll.enabled = state;
        }
        foreach(SphereCollider coll in collidersS){
            coll.enabled = state;
        }
        foreach(Rigidbody rb in rbs){
            rb.isKinematic = !state;
        }
        foreach(XRGrabInteractable grab in grabInteractables){
            grab.enabled = state;
        }
    }
}
