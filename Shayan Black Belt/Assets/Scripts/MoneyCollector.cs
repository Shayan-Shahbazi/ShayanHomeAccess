using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class MoneyCollector : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    private Scraps scrapData;
    private Rigidbody collectedRigidbody;

    private int totalMoney = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pickupable"))
        {
            ConditionChoose itemScript = collision.gameObject.GetComponent<ConditionChoose>();

            if (itemScript != null && itemScript.ScrapData != null)
            {
                totalMoney += itemScript.ScrapData.scrapCost;

                collision.gameObject.layer = 0;

                collectedRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                collectedRigidbody.isKinematic = false;

                moneyText.text = "$" + totalMoney.ToString();
            }
        }
    }
}
