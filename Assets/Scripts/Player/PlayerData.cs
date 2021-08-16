using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] timesW1;
    public float[] timesW2;
    public float[] timesW3;
    public float[] timesW4;
    public float[] timesW5;

    public PlayerData(MenuController controller){
        timesW1 = controller.floatTimeW1;
        timesW2 = controller.floatTimeW2;
        timesW3 = controller.floatTimeW3;
        timesW4 = controller.floatTimeW4;
        timesW5 = controller.floatTimeW5;
    }
}
