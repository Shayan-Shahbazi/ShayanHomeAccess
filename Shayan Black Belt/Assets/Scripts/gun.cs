using Unity.VisualScripting;
using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject fireHold;
    [SerializeField] private float bulletSpeed = 20f;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + (fireRate / FireratePowerup.FireRateMultiplier);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireHold.transform.position, fireHold.transform.transform.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            bullet.transform.localRotation = Quaternion.Euler(90f, bullet.transform.localRotation.y, 90f);
            rb.velocity = fireHold.transform.forward * bulletSpeed;
        }

        Destroy(bullet, 3f);
    }
}
