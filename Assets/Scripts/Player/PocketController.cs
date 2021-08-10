using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PocketController : XRSocketInteractor
{
    GameObject itemInSocket;

    public Renderer[] listOfRends;

    public Renderer rend;

    public Material inM;
    public Material outM;

    GameObject magazine;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        itemInSocket = args.interactable.gameObject;
        
        listOfRends = itemInSocket.GetComponentsInChildren<Renderer>();

        foreach(Renderer rend in listOfRends){
            rend.enabled = false;
        }

        rend.material = inM;
        
        if(itemInSocket.name == "Pistol"){
            magazine = itemInSocket.GetComponentInChildren<AmmoController>().mag;
            if(magazine != null)
            magazine.GetComponentInChildren<Renderer>().enabled = false;
        }
        if(itemInSocket.name == "SMG"){
            magazine = itemInSocket.GetComponentInChildren<AmmoController>().mag;
            if(magazine != null)
            magazine.GetComponentInChildren<Renderer>().enabled = false;
        }
        
        base.OnSelectEntered(args);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        foreach(Renderer rend in listOfRends){
            rend.enabled = true;
        }

        rend.material = outM;

        if(magazine != null){
            magazine.GetComponentInChildren<Renderer>().enabled = true;
            magazine = null;
        }

        base.OnSelectExited(args);
    }
}
