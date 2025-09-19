using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Submarine submarine;
    public AudioSource audioSource;
    public AudioClip boomAudio;
    public AudioClip warningAudio;
    public AudioClip obstacleCollisionAudio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnEnable()
    {
        Submarine.OnPlayerDeath += PlayerDeathAction;
        MinesManager.OnWarningSpawn += WarningSpawnAction;
        Obstacle.OnObstacleCollision += ObstacleCollisionAction;
    }

    private void OnDisable()
    {
        Submarine.OnPlayerDeath -= PlayerDeathAction;
        MinesManager.OnWarningSpawn -= WarningSpawnAction;
        Obstacle.OnObstacleCollision -= ObstacleCollisionAction;
    }

    void PlayerDeathAction()
    {
        audioSource.PlayOneShot(boomAudio, 1f);
    }
    
    void WarningSpawnAction()
    {
        audioSource.PlayOneShot(warningAudio, .7f);
    }

    void ObstacleCollisionAction()
    {
        audioSource.PlayOneShot(obstacleCollisionAudio, 1f);
    }
}
