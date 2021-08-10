using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public GameObject playerPrefab;
    public Transform spawnPoint;
    
    // Update is called once per frame
    void Update()
    {
        if(player == null){
            SpawnPlayer();
        }
    }

    void SpawnPlayer(){
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
    }
}
