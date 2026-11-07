using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBox : MonoBehaviour
{
    private ZombieManager zombieManager;
    public TextMeshProUGUI moneyText;
    private Scraps scrapData;
    private Rigidbody collectedRigidbody;

    private int totalMoney = 0;
    private int pendingMoney = 0;
    private int lastProcessedWave = 0;

    private void Start()
    {
        zombieManager = Object.FindFirstObjectByType<ZombieManager>();
        if (zombieManager == null)
        {
            Debug.LogError("MoneyBox could not find a ZombieManager script in the scene!");
        }
        UpdateMoneyUI();
    }

    private void Update()
    {
        if (zombieManager != null)
        {
            if (zombieManager.WaveNumb > lastProcessedWave)
            {
                lastProcessedWave = zombieManager.WaveNumb;
                if (pendingMoney > 0)
                {
                    totalMoney += pendingMoney;
                    pendingMoney = 0;
                    UpdateMoneyUI();
                    Debug.Log("Wave started! Received pending chunk payout. Total Money: " + totalMoney);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pickupable"))
        {
            ConditionChoose itemScript = collision.gameObject.GetComponent<ConditionChoose>();

            if (itemScript != null && itemScript.ScrapData != null)
            {
                pendingMoney += itemScript.ScrapData.scrapCost;
                collision.gameObject.layer = 0;

                Debug.Log("Item dropped! Pending wave payout grew by: $" + itemScript.ScrapData.scrapCost);

                Destroy(collision.gameObject);
            }
        }
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = "$" + totalMoney.ToString();
        }
    }
}
