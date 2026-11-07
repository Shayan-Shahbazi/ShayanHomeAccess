using UnityEngine;

public class RandomSurfaceSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public int totalSpawnCount = 10;

    public Collider surfaceCollider;
    public float yOffset = 0.5f;

    void Start()
    {
        if (ValidateInputs())
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        Bounds bounds = surfaceCollider.bounds;

        float spawnHeight = bounds.max.y + 50f;

        for (int i = 0; i < totalSpawnCount; i++)
        {
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            GameObject prefabToSpawn = objectsToSpawn[randomIndex];

            if (prefabToSpawn == null) continue;

            Vector3 randomPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                spawnHeight,
                Random.Range(bounds.min.z, bounds.max.z)
            );

            if (Physics.Raycast(randomPosition, Vector3.down, out RaycastHit hit, spawnHeight + 10f))
            {
                if (hit.collider == surfaceCollider)
                {
                    Vector3 spawnPoint = hit.point;
                    spawnPoint.y += yOffset;

                    Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);
                }
                else
                {
                    i--;
                }
            }
            else
            {
                i--;
            }
        }
    }

    bool ValidateInputs()
    {
        if (objectsToSpawn == null || objectsToSpawn.Length == 0)
        {
            Debug.LogError("Please assign at least one GameObject to the Objects To Spawn array.");
            return false;
        }

        if (surfaceCollider == null)
        {
            Debug.LogError("Please assign a Surface Collider in the inspector.");
            return false;
        }

        return true;
    }
}
