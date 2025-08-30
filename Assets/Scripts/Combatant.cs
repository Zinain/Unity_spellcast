using UnityEngine;
using UnityEngine.UI;

public class Combatant : MonoBehaviour
{
    private string combatantName;
    [SerializeField] private int maxHP = 100;
    public int currentHP;
    [SerializeField] private int attackPower;
    [SerializeField] private int defence;
    [SerializeField] private float attackInterval = 1f; //every second;

    [SerializeField] private Slider HpBar;

    private Combatant target;
    public bool taken = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
        InvokeRepeating(nameof(Attack), attackInterval, attackInterval);
    }

    void UpdateHPBar()
    {
        if(HpBar != null)
        {
            HpBar.value = (float)currentHP / maxHP;
        }
    }

    void Attack()
    {
        if(target != null && target.currentHP > 0) 
        {
            target.TakeDamage(attackPower);
        }
    }

    public void TakeDamage(int power)
    {
        currentHP -= power;
        if(currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
        UpdateHPBar();
    }

    void Die()
    {
        Debug.Log(combatantName + " has died!");
        CancelInvoke(nameof(Attack));
        gameObject.SetActive(false);
    }

    public void SetTarget(Combatant newTarget)
    {
        target = newTarget;
    }

    public void ModifyStat(string stat, int amount, float duration)
    {
        switch (stat)
        {
            case "damage":
                attackPower += amount;
                break;

            case "defense":
                defence += amount;
                break;

            case "heal":
                currentHP += amount;
                currentHP = Mathf.Min(currentHP, maxHP);
                break;
        }
        UpdateHPBar();
        if(duration > 0)
        {
            StartCoroutine(RemoveBuff(stat, amount, duration));
        }
    }

    private System.Collections.IEnumerator RemoveBuff(string stat, int amount, float duration)
    {
        yield return new WaitForSeconds(duration);
        switch (stat)
        {
            case "damage":
                attackPower -= amount;
                break;

            case "defense":
                defence -= amount;
                break;

            case "heal":
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
