using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 35;

    private void OnTriggerEnter(Collider other)
    {
        ZombieHealth zombie = other.GetComponent<ZombieHealth>();

        if (zombie != null)
        {
            int finalDamage = Mathf.RoundToInt(
                damageAmount * DamagePowerup.DamageMultiplier
            );

            zombie.TakeDamage(finalDamage);
            Destroy(gameObject); 
        }
    }
}
