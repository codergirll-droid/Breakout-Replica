using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CollusionCollider : MonoBehaviour
{
    public Ball ballMovement;
    [SerializeField] private int lives = 3;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Text lifeTxt;
    [SerializeField] private AudioSource lostALifeSound;
    [SerializeField] private AudioSource gameOverSound;

    void BounceFromRacket(Collision2D c)
    {
        Vector3 ballPoisition = this.transform.position;
        Vector3 racketPosition = c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.x;

        float y;
        if (c.gameObject.name == "Racket")
        {
            y = 1;
        }
        else
        {
            y = -1;
        }

        float x = (ballPoisition.x - racketPosition.x) / racketHeight;
        this.ballMovement.increaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x, y));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Racket")
        {
            this.BounceFromRacket(collision);
        }
        else if (collision.gameObject.name == "downWall")
        {
            lives--;
            lifeTxt.text = "Canlar : " + lives.ToString();
            lostALifeSound.Play();

            Debug.Log("Down collision");
            StartCoroutine(this.ballMovement.StartBall(true));
        }

        if (lives < 1)
        {
            Time.timeScale = 0;
            gameOverSound.Play();
            GameOver.SetActive(true);
        }

    }
}
