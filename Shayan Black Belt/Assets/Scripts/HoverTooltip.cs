using UnityEngine;
using TMPro;
using System.Collections;

public class HoverTooltip : MonoBehaviour
{
    private Outline outlineScript;
    public TextMeshProUGUI tooltipText;
    public TextMeshProUGUI moneyText;

    public GameObject itemPrefab;
    public Texture itemTexture;

    public float itemPrice = 45f;

    private InventoryManager inventory;
    private bool isPurchased = false;
    private bool isWarning = false;

    void Start()
    {
        if (tooltipText != null)
        {
            tooltipText.gameObject.SetActive(false);
        }
        inventory = FindFirstObjectByType<InventoryManager>();
        outlineScript = GetComponent<Outline>();
        if (outlineScript != null)
        {
            outlineScript.enabled = false;
        }
        else
        {
            Debug.LogError("No Outline component found on " + gameObject.name);
        }
    }

    void Update()
    {
        if (isPurchased && Input.GetKeyDown(KeyCode.E))
        {
            if (inventory != null)
            {
                bool wasAdded = inventory.AddItem(itemPrefab, itemTexture);
                if (wasAdded)
                {
                    if (tooltipText != null)
                    {
                        tooltipText.gameObject.SetActive(false);
                    }
                    Destroy(gameObject);
                }
                else
                {
                    if (tooltipText != null && !isWarning)
                    {
                        StartCoroutine(ShowToolbarFull());
                    }
                }
            }
        }
    }

    void OnMouseEnter()
    {
        if (tooltipText != null)
        {
            tooltipText.gameObject.SetActive(true);
        }
        if (outlineScript != null)
        {
            outlineScript.enabled = true;
        }
    }

    void OnMouseOver() { }

    void OnMouseExit()
    {
        if (tooltipText != null)
        {
            tooltipText.gameObject.SetActive(false);
        }
        if (outlineScript != null)
        {
            outlineScript.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (isPurchased) { return; }

        if (moneyText != null)
        {
            string cleanText = moneyText.text.Replace("$", "").Trim();
            if (float.TryParse(cleanText, out float currentMoney))
            {
                if (currentMoney >= itemPrice)
                {
                    currentMoney -= itemPrice;
                    moneyText.text = $"${currentMoney.ToString("F0")}";
                    isPurchased = true;
                    if (tooltipText != null)
                    {
                        tooltipText.text = "Press E To pick up";
                    }
                }
                else
                {
                    if (tooltipText != null && !isWarning)
                    {
                        StartCoroutine(ShowNotEnoughMoney());
                    }
                }
            }
        }
    }

    private IEnumerator ShowNotEnoughMoney()
    {
        isWarning = true;
        string originalText = tooltipText.text;
        tooltipText.text = "Not enough money...";
        yield return new WaitForSeconds(0.5f);
        if (!isPurchased)
        {
            tooltipText.text = originalText;
        }
        isWarning = false;
    }

    private IEnumerator ShowToolbarFull()
    {
        isWarning = true;
        string originalText = tooltipText.text;
        tooltipText.text = "Toolbar is full!";
        yield return new WaitForSeconds(0.5f);
        tooltipText.text = originalText;
        isWarning = false;
    }
}
