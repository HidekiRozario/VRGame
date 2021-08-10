using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    PlayerController player;

    void Start(){
        player = GetComponentInParent<PlayerController>();
    }

    void HitBy(float damage){
        player.Hit(damage);
        return;
    }
}
