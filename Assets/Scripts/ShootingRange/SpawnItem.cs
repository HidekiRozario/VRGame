using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;

    public Transform spawnPoint;

    public void SpawnObject(){
        Instantiate(item, spawnPoint.position, Quaternion.identity);
    }
}
