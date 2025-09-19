using System.Collections;
using UnityEngine;
using System;

public class MinesManager : MonoBehaviour
{
    public GameObject minePrefab;
    public GameObject warningIconPrefab;
    public Collider2D leftBorderCollider;
    public Collider2D rightBorderCollider;
    public float yMinSpawn = -6f;
    public float yMaxSpawn = 6f;
    public float spawnInterval = 8f;
    float currentTime = 0f;
    float timeOfLastSpawn;
    public float minEnterSpeed;
    public float maxEnterSpeed;
    public bool isEnabled = true;
    public static event Action OnWarningSpawn;

    void Start()
    {
        timeOfLastSpawn = 2f; // first one spawns sooner
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeOfLastSpawn + spawnInterval)
        {
            if (isEnabled)
            {
                SpawnMine();
                timeOfLastSpawn = currentTime;
            }
        }
    }

    void SpawnMine()
    {
        bool spawnSide = UnityEngine.Random.value > 0.5f; // <0.5 is left, >0.5 is right
        StartCoroutine(MineSpawnCoroutine(spawnSide));
    }

    IEnumerator MineSpawnCoroutine(bool spawnSide)
    {
        float ySpawn = UnityEngine.Random.Range(yMinSpawn, yMaxSpawn);
        float warningIconTime = 3f;

        // warning icon
        Debug.Log("Spawning Warning icon");
        OnWarningSpawn.Invoke();
        Vector3 warningIconPos = new Vector3((spawnSide ? -11.8f : 11.8f), ySpawn, 0);
        GameObject warningIcon = Instantiate(warningIconPrefab, warningIconPos, Quaternion.identity);
        Destroy(warningIcon, warningIconTime);

        yield return new WaitForSeconds(warningIconTime);

        // mine 
        Vector3 minePos = new Vector3((spawnSide ? -13.5f : 13.5f), ySpawn, 0);
        Debug.Log($"Spawning mine on the {(spawnSide ? "left" : "right")} at y={ySpawn}");
        GameObject mine = Instantiate(minePrefab, minePos, Quaternion.identity);
        Rigidbody2D mineRB = mine.GetComponent<Rigidbody2D>();
        Collider2D mineCollider = mine.GetComponent<Collider2D>();

        Physics2D.IgnoreCollision((spawnSide ? leftBorderCollider : rightBorderCollider), mineCollider, true);
        float randomSpeed = UnityEngine.Random.Range(minEnterSpeed, maxEnterSpeed);
        Vector2 forceVector = randomSpeed * new Vector2((spawnSide ? 1 : -1), 0);
        mineRB.AddForce(forceVector);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision((spawnSide ? leftBorderCollider : rightBorderCollider), mineCollider, false);
        yield break;
    }
}
