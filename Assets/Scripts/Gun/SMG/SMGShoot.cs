using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SMGShoot : Weapon
{
    //AUTOFIRECOOLDOWN
    public float timeCooldown = 0.1f;
    float time = 0;

    // Update is called once per frame
    void Update()
    {
        if(controllerHoldingGun != null){
            if(controllerHoldingGun.activateAction.action.ReadValue<float>() > 0.95f){
                if(time <= 0){
                    Shoot();
                    time = timeCooldown;
                }
            }
        }

        if(time > 0){
            time -= Time.deltaTime;
        }
        
        LoadBullet();
        DetachMag();
    }
}
