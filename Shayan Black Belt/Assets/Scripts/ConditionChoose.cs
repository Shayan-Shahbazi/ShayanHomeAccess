using UnityEngine;

public class ConditionChoose : MonoBehaviour
{
    public Scraps ScrapData;

    void Start()
    {
        if (!gameObject.CompareTag("Pickupable"))
        {
            Debug.LogWarning($"'{gameObject.name}' is missing the 'Pickupable' tag. Script disabled.");
            enabled = false;
            return;
        }

        int count = Random.Range(1, 151);

        if (ScrapData != null)
        {
            if (count >= 1 && count <= 10)
            {
                ScrapData.scrapConditionVisualizer = "Bad Condition";
                ScrapData.scrapCost = Random.Range(5, 16);
            }
            else if (count >= 11 && count <= 50)
            {
                ScrapData.scrapConditionVisualizer = "Decent Condition";
                ScrapData.scrapCost = Random.Range(16, 26);
            }
            else if (count >= 51 && count <= 70)
            {
                ScrapData.scrapConditionVisualizer = "Good Condition";
                ScrapData.scrapCost = Random.Range(26, 46);
            }
            else if (count >= 71 && count <= 100)
            {
                ScrapData.scrapConditionVisualizer = "Excellent Condition";
                ScrapData.scrapCost = Random.Range(41, 71);
            }
            else if (count >= 101 && count <= 150)
            {
                ScrapData.scrapConditionVisualizer = "Godly Condition";
                ScrapData.scrapCost = Random.Range(71, 141);
            }

            Debug.Log($"{gameObject.name} generated as {ScrapData.scrapConditionVisualizer} worth ${ScrapData.scrapCost}");
        }
    }
}
