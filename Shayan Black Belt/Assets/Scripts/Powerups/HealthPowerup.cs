using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class HealthPowerup : MonoBehaviour
{
    public PlayerStats stats;
    public MoneyFix MoneyFix;
    public int PowerupPrice = 20;
    public TextMeshProUGUI PowerupPriceText;
    private string cleanText;
    private void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();
        MoneyFix = FindFirstObjectByType<MoneyFix>();

        if (stats == null) Debug.Log("Couldn't Find Stats");
        if (MoneyFix == null) Debug.Log("Couldn't Find MoneyFix");
        cleanText = PowerupPriceText.text.Replace("$", "").Trim();
    }
    public void onButtonPressed()
    {
        if (stats == null || MoneyFix == null)
        {
            Debug.LogError("caawdfwfwga");
            return;
        }
        if (MoneyFix.TextValue >= PowerupPrice)
        {
            Debug.Log("Bought");
            PowerupPriceText.text = PowerupPrice.ToString();
            MoneyFix.TextValue -= PowerupPrice;
            PowerupPrice *= 2;
            stats.healthMulti *= 1.05f;
            stats.health.currentHealth = Mathf.RoundToInt(stats.health.currentHealth * 1.05f);
            stats.health.healthText.text = stats.health.currentHealth.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}