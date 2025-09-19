using UnityEngine;
using System;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D rb;

    // Speed
    float minSpeed = 100f;
    float maxSpeed = 150f; 
    public static event Action OnObstacleCollision;
    public ParticleSystem clangEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 randomDirection = UnityEngine.Random.insideUnitCircle;
        float randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomDirection * randomSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (transform.position.x > collision.gameObject.transform.position.x)
            {
                // this should make it so that one mine does stuff 
                OnObstacleCollision.Invoke();
                Instantiate(clangEffect, (transform.position + collision.gameObject.transform.position)/2, transform.rotation);
            }
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit player.");
        }
        else
        {
            OnObstacleCollision.Invoke();
        }
    }
}
