using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    TimeStorage container;
    PlayerData data;

    public Button[] levelTimesW1;
    public Button[] levelTimesW2;
    public Button[] levelTimesW3;
    public Button[] levelTimesW4;
    public Button[] levelTimesW5;

    public float[] floatTimeW1 = new float[10];
    public float[] floatTimeW2 = new float[10];
    public float[] floatTimeW3 = new float[10];
    public float[] floatTimeW4 = new float[10];
    public float[] floatTimeW5 = new float[10];

    void Start(){
        LoadPlayer();
        if(GameObject.Find("TimeContainer") != null){
            container = GameObject.Find("TimeContainer").GetComponent<TimeStorage>();
            CheckWorld();
        }
        LoadTimes();
    }

    void CheckWorld(){
        switch(container.levelWorld){
            case "World 1": 
                CheckTime(levelTimesW1, floatTimeW1);
                break;
            case "World 2": 
                CheckTime(levelTimesW2, floatTimeW2);
                break;
            case "World 3": 
                CheckTime(levelTimesW3, floatTimeW3);
                break;
            case "World 4": 
                CheckTime(levelTimesW4, floatTimeW4);
                break;
            case "World 5": 
                CheckTime(levelTimesW5, floatTimeW5);
                break;
        }
    }

    void CheckTime(Button[] times, float[] floatTimes){
        foreach(Button btn in times){
            int i = 0;
            if(btn.name == container.levelName){
                if(floatTimes[i] > container.time || floatTimes[i] == 0){
                    floatTimes[i] = container.time;
                    SavePlayer();
                }
                break;
            }
            i++;
        }
    }

    public void SavePlayer(){
        SaveSystem.SaveData(this);
    }

    public void LoadPlayer(){
        data = SaveSystem.LoadData(this);

        floatTimeW1 = data.timesW1;
        floatTimeW2 = data.timesW2;
        floatTimeW3 = data.timesW3;
        floatTimeW4 = data.timesW4;
        floatTimeW5 = data.timesW5;
    }

    public void LoadTimes(){
        List<float[]> times = new List<float[]> { floatTimeW1, floatTimeW2, floatTimeW3, floatTimeW4, floatTimeW5 };
        List<Button[]> btnTimes = new List<Button[]> { levelTimesW1, levelTimesW2, levelTimesW3, levelTimesW4, levelTimesW5 };

        int i = 0;
        int j = 0;

        foreach(float[] timeArr in times){
            foreach(float time in timeArr){
                Button[] tempBtn = btnTimes[i];
                tempBtn[j].transform.GetChild(1).GetComponent<Text>().text = time.ToString("F2");
                j++;
            }
            j = 0;
            i++;
        }
    }
}
