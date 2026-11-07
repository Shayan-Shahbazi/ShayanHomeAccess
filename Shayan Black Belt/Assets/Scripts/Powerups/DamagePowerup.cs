
using TMPro;
using UnityEngine;

public class DamagePowerup : MonoBehaviour
{
    public PlayerStats stats;
    public MoneyFix MoneyFix;
    public int PowerupPrice = 20;
    public TextMeshProUGUI PowerupPriceText;

    public static float DamageMultiplier = 1f;

    private void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();
        MoneyFix = FindFirstObjectByType<MoneyFix>();

        if (PowerupPriceText != null)
        {
            PowerupPriceText.text = "$" + PowerupPrice.ToString();
        }

        if (stats == null) Debug.Log("Couldn't Find Stats");
        if (MoneyFix == null) Debug.Log("Couldn't Find MoneyFix");
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
                stats.moneyText.text = "$" + MoneyFix.TextValue.ToString();
            }

            DamageMultiplier += 0.1f;

            PowerupPrice *= 2;

            if (PowerupPriceText != null)
            {
                PowerupPriceText.text = "$" + PowerupPrice.ToString();
            }

            Debug.Log("Damage multiplier upgraded to " +
                      DamageMultiplier + "x");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
