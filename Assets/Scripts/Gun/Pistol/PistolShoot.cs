using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolShoot : Weapon
{
    private bool canShoot = true;
    
    void Update()
    {
        if(controllerHoldingGun != null){
            if(controllerHoldingGun.activateAction.action.ReadValue<float>() > 0.95f && canShoot){
               canShoot = false;
               Shoot();
            }
            if(controllerHoldingGun.activateAction.action.ReadValue<float>() < 0.95f){
                canShoot = true;
            }
        }

        LoadBullet();
        DetachMag();
    }
}
