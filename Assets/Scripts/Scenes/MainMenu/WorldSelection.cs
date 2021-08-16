using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelection : MonoBehaviour
{
    public GameObject show;
    public GameObject[] hides;

    public void OnClick(){
        show.SetActive(true);

        foreach(GameObject hide in hides){
            hide.SetActive(false);
        }
    }
}
