using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float extraSpeed;
    [SerializeField] private float maxSpeed;
    int hitCounter = 0;
    [SerializeField] private AudioSource racketBounce;
    [SerializeField] private AudioSource wallBounce;
    [SerializeField] private AudioSource brickBreak;


    void Start()
    {
        StartCoroutine(this.StartBall());
    }
    void PositionBall()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
    }

    public IEnumerator StartBall(bool isStartingPlayer = true)
    {
        this.PositionBall();

        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer)
            this.MoveBall(new Vector2(0, -1));

    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeed;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = dir * speed;
    }

    public void increaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeed <= this.maxSpeed)
        {
            this.hitCounter++;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("brick"))
        {
            brickBreak.Play();

            Destroy(other.gameObject);
            
           
        }else if (other.gameObject.tag.Equals("wall"))
        {
            wallBounce.Play();
        }else if (other.gameObject.tag.Equals("Player"))
        {
            racketBounce.Play();
        }
    }


}
