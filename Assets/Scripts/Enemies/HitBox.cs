using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    BasicBoi enemy;
    public float dmgMultiplier;
    MeshRenderer mesh;

    float changeTime = 0;
    public float changeCooldown = 0.2f;

    void Start(){
        mesh = GetComponent<MeshRenderer>();
        enemy = GetComponentInParent<BasicBoi>();
        mesh.enabled = false;
    }

    void Update(){
        if(changeTime > 0){
            mesh.enabled = true;
            changeTime -= Time.deltaTime;
        }else{
            mesh.enabled = false;
        }
    }

    void HitBy(float damage){
        enemy.Hit(damage * dmgMultiplier);
        changeTime = changeCooldown;
        return;
    }
}
