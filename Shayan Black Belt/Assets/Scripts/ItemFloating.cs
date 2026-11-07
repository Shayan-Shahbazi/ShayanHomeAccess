using UnityEngine;

public class ItemFloating : MonoBehaviour
{
    [Header("Floating Settings")]
    [Tooltip("How fast the object moves up and down.")]
    public float floatSpeed = 2f;

    [Tooltip("How far the object moves from its starting position.")]
    public float floatAmplitude = 0.5f;

    [Header("Rotation Settings")]
    [Tooltip("How fast the object spins around its Y-axis.")]
    public float rotationSpeed = 50f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
