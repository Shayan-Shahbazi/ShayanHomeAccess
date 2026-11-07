using UnityEngine;

public class RandomMedSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject plane;

    [Range(0f, 1f)]
    public float spawnChance = 0.2f;

    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating(nameof(TrySpawn), spawnInterval, spawnInterval);
    }

    void TrySpawn()
    {
        // 20% chance to spawn a prefab
        if (Random.value > spawnChance)
            return;

        // Get the plane's size
        Renderer planeRenderer = plane.GetComponent<Renderer>();

        if (planeRenderer == null)
        {
            Debug.LogError("The plane needs a Renderer component!");
            return;
        }

        Bounds bounds = planeRenderer.bounds;

        // Pick a random position within the plane's bounds
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        // Place the prefab slightly above the plane
        Vector3 spawnPosition = new Vector3(
            randomX,
            bounds.max.y,
            randomZ
        );

        // Spawn the prefab
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}