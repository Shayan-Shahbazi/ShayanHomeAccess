using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    public float maxRange = 1.4f;
    public LayerMask keyMask;
    private void Update()
    {
        scanAroundPosition();
    }

    private void scanAroundPosition()
    {
        Vector3 scanOrigin = transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(scanOrigin, maxRange, keyMask);

        foreach (Collider col in hitColliders)
        {

            Debug.Log($"Found: {col.transform.parent.name}");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, maxRange);
    }
}