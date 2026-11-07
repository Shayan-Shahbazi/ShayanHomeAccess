
using TMPro;
using UnityEngine;

public class FireratePowerup : MonoBehaviour
{
    public GameObject playerHolding;
    public PlayerStats stats;
    public MoneyFix MoneyFix;
    public int PowerupPrice = 20;
    public TextMeshProUGUI PowerupPriceText;

    public static float FireRateMultiplier = 1f;

    private void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();
        MoneyFix = FindFirstObjectByType<MoneyFix>();

        if (PowerupPriceText != null)
        {
            PowerupPriceText.text = "$" + PowerupPrice;
        }

        if (stats == null) Debug.LogError("Couldn't find PlayerStats");
        if (MoneyFix == null) Debug.LogError("Couldn't find MoneyFix");
    }

    public void onButtonPressed()
    {
        if (stats == null || MoneyFix == null)
        {
            Debug.LogError("PlayerStats or MoneyFix is missing!");
            return;
        }

        if (MoneyFix.TextValue >= PowerupPrice)
        {
            MoneyFix.TextValue -= PowerupPrice;

            if (stats.moneyText != null)
            {
                stats.moneyText.text = "$" + MoneyFix.TextValue;
            }

            FireRateMultiplier += 0.1f;
            PowerupPrice *= 2;

            if (PowerupPriceText != null)
            {
                PowerupPriceText.text = "$" + PowerupPrice;
            }

            Debug.Log("Fire rate multiplier: " + FireRateMultiplier + "x");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
