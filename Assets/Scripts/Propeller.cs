using NUnit.Framework;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public bool isSpinning = false;

    [Tooltip("The speed at which the propeller will rotate in degrees per second.")]
    public float rotationSpeed = 720f;
    private Quaternion initialRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (!isSpinning)
        {
            transform.localRotation = initialRotation;
        }
    }

    public void StartSpinning()
    {
        isSpinning = true;
    }

    public void StopSpinning()
    {
        isSpinning = false;
    }

    public bool IsSpinning()
    {
        return isSpinning; 
    }
}
