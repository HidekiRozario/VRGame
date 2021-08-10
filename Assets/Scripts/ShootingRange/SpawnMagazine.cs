using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SpawnMagazine : XRSimpleInteractable
{
    GameObject magIn;

    public GameObject magazinePrefab;
    public Transform spawnPoint;

    public void SpawnMag(){
        magIn = Instantiate(magazinePrefab, spawnPoint.position, Quaternion.identity);
    }

    protected override void OnDestroy()
    {
        Destroy(magIn);
        base.OnDestroy();
    }
}
