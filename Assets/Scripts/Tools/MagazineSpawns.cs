using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagazineSpawns : MonoBehaviour
{
    public GameObject magPrefab;

    public Transform magPoint;


    bool canSpawn = false;
    float timeCooldown = 3f;
    float time;

    void Start(){
        Instantiate(magPrefab, magPoint.position, Quaternion.identity);
    }

    void Update(){
        if(time > 0)
        time -= Time.deltaTime;
        if(time <= 0 && canSpawn){
            canSpawn = false;
            Instantiate(magPrefab, magPoint.position, Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider coll){
        if(coll.CompareTag("PistolMagazine")){
            time = timeCooldown;
            canSpawn = true;
        }
    }
}
