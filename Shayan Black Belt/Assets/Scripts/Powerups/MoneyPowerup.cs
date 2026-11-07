
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPowerup : MonoBehaviour
{
    public MoneyFix MoneyFix;
    public PlayerStats stats;
    public int PowerupPrice = 20;
    public TextMeshProUGUI PowerupPriceText;

    public float MoneyMultiplier = 1f;

    private string cleanText;
    private int lastKnownMoney;

    void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();
        MoneyFix = FindFirstObjectByType<MoneyFix>();

        if (stats != null) Debug.Log("Stats found");
        if (MoneyFix != null) Debug.Log("MoneyFix found");

        if (MoneyFix != null)
        {
            lastKnownMoney = MoneyFix.TextValue;
        }

        if (PowerupPriceText != null)
        {
            PowerupPriceText.text = "$" + PowerupPrice.ToString();
        }
    }

    void Update()
    {
        if (MoneyFix == null)
        {
            return;
        }

        int currentMoney = MoneyFix.TextValue;
        int addedMoney = currentMoney - lastKnownMoney;

        if (addedMoney > 0)
        {
            int bonusMoney = Mathf.RoundToInt(
                addedMoney * (MoneyMultiplier - 1f)
            );

            MoneyFix.TextValue += bonusMoney;

            Debug.Log(
                "Money added: $" + addedMoney +
                ", Multiplier: " + MoneyMultiplier + "x" +
                ", Bonus: $" + bonusMoney
            );
        }

        lastKnownMoney = MoneyFix.TextValue;
    }


    public void OnButtonPressed()
    {
        if (stats == null || MoneyFix == null)
        {
            Debug.LogError("PlayerStats or MoneyFix is missing!");
            return;
        }

        if (MoneyFix.TextValue >= PowerupPrice)
        {
            MoneyFix.TextValue -= PowerupPrice;

            // Update the money UI immediately
            if (stats.moneyText != null)
            {
                stats.moneyText.text = "$" + MoneyFix.TextValue;
            }

            MoneyMultiplier += 0.5f;
            PowerupPrice *= 2;

            if (PowerupPriceText != null)
            {
                PowerupPriceText.text = "$" + PowerupPrice;
            }

            lastKnownMoney = MoneyFix.TextValue;

            Debug.Log("Money Multiplier upgraded to " +
                      MoneyMultiplier + "x");
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

}
