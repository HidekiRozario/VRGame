using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : XRGrabInteractable
{
    //SHOOTING
    private int handType;


    public bool bulletInChamber = false;
    public float damage;

    InputManager inputManager;

    public ActionBasedController controllerHoldingGun;

    public Transform rayPoint;
    public Transform weaponOffset;
    public GameObject weaponHit;

    public AmmoController ammoController;
    //ANIMATION
    public Animator weaponAnim;
    public MuzzleFlash weaponMuzzle;

    private string weaponFireAnim = "GunFire";
    private string weaponFireEmptyAnim = "GunFireEmpty";

    void Start()
    {
        inputManager = GameObject.Find("XR Rig").GetComponent<InputManager>();
    }

    public void DetachMag(){
        //HAND CONTROLLER FOR DETACH
        if(inputManager.primaryButtonRight && handType == 2){
            ammoController.Detach();
        } 
        if(inputManager.primaryButtonLeft && handType == 1){
            ammoController.Detach();
        }
    }
    public void LoadBullet(){
        if(!bulletInChamber){
            ammoController.GetMagAmmo();
        }
    }

    public void Shoot(){
        if(bulletInChamber){
            RaycastHit hit;

            weaponAnim.Play(weaponFireAnim, 0, 0.0f);
            weaponMuzzle.OnGunShot();

            int layerMask = 1 << 17;
            layerMask = ~layerMask;

            if(Physics.Raycast(rayPoint.position, rayPoint.forward, out hit, float.PositiveInfinity, layerMask)){
                Instantiate(weaponHit, hit.point, Quaternion.identity);

                if(hit.collider.tag == "Target")
                {
                hit.collider.SendMessageUpwards("HitBy", damage);
                }

                if(hit.collider.tag == "HitLayer")
                {
                hit.collider.SendMessage("HitBy", damage);
                }
            }

            bulletInChamber = false;
        }
        else{
            weaponAnim.Play(weaponFireEmptyAnim, 0, 0.0f);
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        controllerHoldingGun = args.interactor.gameObject.GetComponent<ActionBasedController>();

        if(args.interactor.gameObject.tag == "LeftHand")
            handType = 1;
        else
            handType = 2;

        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        handType = 0;
        controllerHoldingGun = null;
        base.OnSelectExited(args);
    }
}
