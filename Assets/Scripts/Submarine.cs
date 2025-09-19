using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Submarine : MonoBehaviour
{
    // Movement
    public Propeller propeller;
    public float thrustForce = 2f;
    public float maxSpeed = 5f;
    Rigidbody2D rb;

    // UI and Scoring
    public UIDocument uIDocument;
    private Label scoreText;
    private Button restartButton;
    public GameObject borders;
    private float elapsedTime = 0f;
    public float scoreMultiplier = 10f;
    private float score = 0f;

    // Other 
    public GameObject explosionEffect;
    public MinesManager minesManager;
    public ParticleSystem bubbleParticles;
    public static event Action OnPlayerDeath;


    void Start()
    {
        scoreText = uIDocument.rootVisualElement.Q<Label>("ScoreLabel");
        restartButton = uIDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.clicked += ReloadScene;
        restartButton.style.display = DisplayStyle.None;
        rb = GetComponent<Rigidbody2D>();
        bubbleParticles.Stop();

        // for safety
        if (propeller is null)
        {
            propeller = gameObject.GetComponentInChildren<Propeller>();
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        scoreText.text = $"Score: {score}";

        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value); // Get mouse position
            Vector2 direction = (mousePos - transform.position).normalized; // Without normalizing, the speed is influenced by how far away you click (magnitude of vector)
            transform.up = direction; // Makes the sub's 'up' direction face the mouse
            rb.AddForce(direction * thrustForce); // Apply thrust
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed; // Limits the speed
            }

            propeller.StartSpinning();
            if (!bubbleParticles.isPlaying)
            {
                bubbleParticles.Play();
            }
        }
        else
        {
            propeller.StopSpinning();
            if (bubbleParticles.isPlaying)
            {
                bubbleParticles.Stop();
            }
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        OnPlayerDeath.Invoke();
        Destroy(gameObject);
        Destroy(collision.gameObject);
        borders.SetActive(false);
        minesManager.isEnabled = false;
        restartButton.style.display = DisplayStyle.Flex;
    }
}
