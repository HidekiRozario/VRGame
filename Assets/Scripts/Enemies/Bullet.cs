using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;

    void Start(){
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider coll){
        if(coll.tag == "PlayerHitbox"){
            coll.transform.SendMessage("HitBy", damage);
        }
            Destroy(gameObject);
    }
}
