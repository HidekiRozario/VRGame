using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject UIElement;

    public GameObject UIItself;

    public void Select(){
        UIElement.SetActive(true);
        UIItself.SetActive(false);
    }
}
