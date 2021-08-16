using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float damage;
    public float speed = 15f;

    public GameObject weaponHit;

    Rigidbody rb;

    void Start(){
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    void Update(){
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, 0.5f)){
            if(hit.transform.tag == "HitLayer"){
                hit.transform.SendMessage("HitBy", damage);
                Instantiate(weaponHit, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if(hit.transform.tag == "Target"){
                hit.transform.SendMessageUpwards("HitBy", damage);
                Instantiate(weaponHit, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    /*
    void OnTriggerEnter(Collider coll){
        if(coll.tag == "HitLayer"){
            coll.SendMessage("HitBy", damage);
        }
        else if(coll.tag == "Target"){
            coll.SendMessageUpwards("HitBy", damage);
        }
    }
    */
}
