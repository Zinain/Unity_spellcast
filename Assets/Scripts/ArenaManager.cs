using UnityEngine;
using System.Collections.Generic;
public class ArenaManager : MonoBehaviour
{
    [SerializeField] private List<Combatant> allies;
    [SerializeField] private List<Combatant> enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupCombat();
    }

    void SetupCombat()
    {
        /*foreach(var ally in allies)
        {
            if(enemies.Count > 0)
            {
                foreach (var enemy in enemies)
                {
                    if(!ally.taken && !enemy.taken)
                    {
                        ally.SetTarget(enemy);
                        ally.taken = true;
                        enemy.SetTarget(ally);
                        enemy.taken = true;
                    }
                }
            }
        }*/
        // simple: each ally attacks the first enemy, and vice versa
        foreach (var ally in allies)
        {
            if (enemies.Count > 0)
                ally.SetTarget(enemies[0]);
        }

        foreach (var enemy in enemies)
        {
            if (allies.Count > 0)
                enemy.SetTarget(allies[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        allies.RemoveAll(a => a == null || a.currentHP <= 0);
        enemies.RemoveAll(e => e == null || e.currentHP <= 0);

        if (allies.Count == 0)
        {
            Debug.Log("Enemies Win!");
        }
        else if (enemies.Count == 0)
        {
            Debug.Log("Allies Win!");
        }
    }
}
