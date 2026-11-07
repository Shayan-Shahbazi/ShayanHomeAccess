using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth = 100;
    public TextMeshProUGUI healthText;

    private bool isDead = false;

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth < 0) currentHealth = 0;

        Debug.Log($"Player hit! Remaining Health: {currentHealth}");
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");
        SceneManager.LoadScene(1);
    }
}
