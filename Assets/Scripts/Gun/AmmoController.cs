using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoController : XRSocketInteractor
{
    public bool magazineIn = false;
    public string gunType;
    public float socketDelay;

    float timeSocket;

    //UPRAVIT NA WEAPON 
    public Weapon weapon;

    public Magazine magScript;

    public GameObject mag;

    public void Update(){
        if(!socketActive){
            timeSocket -= Time.deltaTime;
            if(timeSocket <= 0){
                socketActive = true;
            }
        }
    }

    public void Detach(){
        socketActive = false;
        timeSocket = socketDelay;
    }

    public override bool CanSelect(XRBaseInteractable interactable)
    {
        return base.CanSelect(interactable) && interactable.CompareTag(gunType);
    }

    public void MagazineCheck(){
        magazineIn = !magazineIn;

        if(!magazineIn){
            if(magScript != null)
            magScript.attached = !magScript.attached;
            mag = null;
            magScript = null;
        }
        else
        {
        magScript = selectTarget.GetComponent<Magazine>();
        mag = selectTarget.gameObject;
        magScript.attached = !magScript.attached;
        }
    }

    public void UnloadBullet(){
        if(magScript != null)
        magScript.bullets--;
    }

    public void GetMagAmmo(){
        if(magazineIn){
            if(magScript.bullets > 0){
                weapon.bulletInChamber = true;
                UnloadBullet();
            }
        }
    }
}
