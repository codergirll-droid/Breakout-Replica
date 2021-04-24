using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toLevelSelection : MonoBehaviour
{
    public void loadLevels()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelection");
    }
}
