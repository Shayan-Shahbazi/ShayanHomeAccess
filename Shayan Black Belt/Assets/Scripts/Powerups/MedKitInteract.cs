using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitInteract : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats stats =
                collision.gameObject.GetComponentInParent<PlayerStats>();

            if (stats == null)
            {
                stats = collision.gameObject.GetComponentInChildren<PlayerStats>();
            }

            if (stats != null)
            {
                stats.health.currentHealth =
                    Mathf.RoundToInt(stats.health.currentHealth + 20f);

                stats.health.healthText.text =
                    stats.health.currentHealth.ToString();

                // Remove the medkit
                Destroy(gameObject);
            }
        }
    }
}