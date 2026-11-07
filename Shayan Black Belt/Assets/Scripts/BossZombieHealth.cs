
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class BossZombieHealth : MonoBehaviour
{
    public int currentHealth = 300;
    public string deathAnimationName = "Death";
    public Transform playerTransform;
    public string runAnimationName = "Run";
    public string idleAnimationName = "Idle";
    public string attackAnimationName = "Attack1";
    public int attackDamage = 15;
    public float attackRange = 2.0f;
    public float attackCooldown = 1.5f;
    public int killReward = 10;
    public TextMeshProUGUI moneyTextUI;
    public Animator zombieAnimator;
    private NavMeshAgent navAgent;
    private PlayerHealth playerHealth;
    private bool isDead = false;
    private float nextAttackTime = 0f;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        if (zombieAnimator == null)
        {
            zombieAnimator = GetComponentInChildren<Animator>();
        }
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
        if (playerTransform != null)
        {
            playerHealth = playerTransform.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (isDead || playerTransform == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attackRange)
        {
            navAgent.isStopped = true;
            TryAttack();
        }
        else
        {
            navAgent.isStopped = false;
            navAgent.SetDestination(playerTransform.position);
            ManageLocomotionAnimations();
        }
    }

    private void TryAttack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (zombieAnimator != null)
            {
                zombieAnimator.Play(attackAnimationName);
            }
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
            nextAttackTime = Time.time + attackCooldown;
        }
    }

    private void ManageLocomotionAnimations()
    {
        if (zombieAnimator == null) return;

        bool isMovingNow = navAgent.velocity.magnitude > 0.1f;
        if (isMovingNow)
        {
            zombieAnimator.Play(runAnimationName);
        }
        else
        {
            zombieAnimator.Play(idleAnimationName);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        MoneyFix moneyFix = FindFirstObjectByType<MoneyFix>();

        if (moneyFix != null)
        {
            moneyFix.TextValue += killReward;

            if (moneyFix.stats != null && moneyFix.stats.moneyText != null)
            {
                moneyFix.stats.moneyText.text = "$" + moneyFix.TextValue.ToString();
            }

            Debug.Log("Boss killed! Earned $" + killReward +
                      ". Money after kill: $" + moneyFix.TextValue);
        }
        else
        {
            Debug.LogWarning("MoneyFix not found! Boss kill reward was not added.");
        }

        if (navAgent != null)
        {
            navAgent.isStopped = true;
            navAgent.enabled = false;
        }
        if (zombieAnimator != null)
        {
            zombieAnimator.Play(deathAnimationName);
        }

        Destroy(gameObject, 3f);
    }
}
