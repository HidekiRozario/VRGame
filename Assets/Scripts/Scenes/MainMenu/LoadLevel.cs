using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public int levelSceneIndex;

    public void Load(){
        SceneManager.LoadScene(levelSceneIndex);
    }
}
