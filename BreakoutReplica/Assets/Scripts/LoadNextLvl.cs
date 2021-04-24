using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLvl : MonoBehaviour
{
    public void LoadNext()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        int sceneInt = scene.buildIndex + 1;
        SceneManager.LoadScene(sceneInt);
    }
    
}
