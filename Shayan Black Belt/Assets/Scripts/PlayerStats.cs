using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public int moneyMulti;

    public PlayerHealth health;
    public TextMeshProUGUI healthText;
    public float healthMulti;

    public PlayerMovement speed;
    public float speedMulti;

    private PlayerMovement jumpForce;
    private float jumpMulti;

    private BulletDamage damage;
    private int damageMulti;

    private gun firerate;
    private int firerateMulti;
    /*public static PlayerStats Instance { get; private set; }

    [Header("UI Reference")]
    public TextMeshProUGUI moneyText;

    [Header("Economy Data")]
    public float currentMoney = 0f;
    public float incomeMultiplier = 1.00f;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        UpdateMoneyUI();
    }

    public void EarnMoney(float baseAmount)
    {
        currentMoney += baseAmount * incomeMultiplier;
        UpdateMoneyUI();
    }

    public bool SpendMoney(float amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            return true;
        }
        return false;
    }

    public void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"${currentMoney.ToString("F0")}";
        }
    }*/
}
