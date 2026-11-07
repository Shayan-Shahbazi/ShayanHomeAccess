using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyFix : MonoBehaviour
{
    public PlayerStats stats;

    public int TextValue;

    private void Start()
    {
        if (stats == null || stats.moneyText == null)
        {
            Debug.LogError("PlayerStats or moneyText is missing!");
            return;
        }

        string cleanText = stats.moneyText.text.Replace("$", "").Trim();

        if (int.TryParse(cleanText, out int result))
        {
            TextValue = result;
        }
    }

    private void Update()
    {
        if (stats != null && stats.moneyText != null)
        {
            string cleanText = stats.moneyText.text.Replace("$", "").Trim();

            if (int.TryParse(cleanText, out int result))
            {
                TextValue = result;
            }
        }
    }
}
