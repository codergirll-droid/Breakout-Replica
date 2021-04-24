using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class RcaketBehaviour : MonoBehaviour
{
    [SerializeField] private float _RacketSpeed = 200f;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private GameObject winPanel;
    private LevelScript Level;

    private void FixedUpdate()
    {
        float v = CrossPlatformInputManager.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0) * _RacketSpeed;
        if(GameObject.FindGameObjectsWithTag("brick").Length == 0)
        {
            if(SceneManager.GetActiveScene().name == "Level36")
            {
                return;
            }
            else
            {
                Level = FindObjectOfType<LevelScript>();
                //Level.Pass();
                int currentLevel = SceneManager.GetActiveScene().buildIndex;

                if (currentLevel >= PlayerPrefs.GetInt("levelIsUnlocked"))
                {
                    PlayerPrefs.SetInt("levelIsUnlocked", currentLevel + 1);
                }

                Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelIsUnlocked") + " UNLOCKED");
            }
            
            winPanel.SetActive(true);
            winSound.Play();
            Time.timeScale = 0;
            Debug.Log("You won");
        }
    }

}
