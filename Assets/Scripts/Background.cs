using UnityEngine;

public class Background : MonoBehaviour
{
    [Range(-10f, 26f)]
    [SerializeField] public float xOffset;

    [Range(-27f, -1f)]
    [SerializeField] public float yOffset;

    public Vector3 initialPosition;
    public float xSpeed;
    public float ySpeed;
    [SerializeField]
    public bool isOverlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = new Vector3(Random.Range(-10f, -2f), Random.Range(-27f, -19f), 0);
        transform.localPosition = initialPosition;
        xSpeed = 0.04f;
        ySpeed = 0.06f;
        if (isOverlay)
        {
            xSpeed = 0.05f;
            ySpeed = 0.03f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newX;
        float newY;
        if (isOverlay)
        {
            float tX = (Mathf.Sin(Time.time * xSpeed) + 1f) / 2f;
            newX = Mathf.Lerp(initialPosition.x, 26f, tX);

            float tY = (Mathf.Sin(Time.time * ySpeed) + 1f) / 2f;
            newY = Mathf.Lerp(initialPosition.y, -1f, tY);
        }
        else
        {
            float tX = (Mathf.Sin(Time.time * xSpeed) + 1f) / 2f;
            newX = Mathf.Lerp(26f, initialPosition.x, tX);

            float tY = (Mathf.Sin(Time.time * ySpeed) + 1f) / 2f;
            newY = Mathf.Lerp(-1f, initialPosition.y, tY);
        }

        transform.position = new Vector3(newX, newY, 0f);
    }
}
