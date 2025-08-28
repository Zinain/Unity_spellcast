using UnityEngine;
using System.Collections.Generic;

public class SpellCast : MonoBehaviour
{
    private List<PrayerBlock> blocks = new List<PrayerBlock>();
    public SpellUIManager uimanager;
    public void AddBlock(PrayerBlock block)
    {
        blocks.Add(block);
        Debug.Log("Added block" + block.blockName);
        uimanager.NextPanel();
    }

    public void CastSpell()
    {
        Debug.Log("Casting spell of " + blocks.Count + " blocks");

        foreach (var block in blocks)
        {
            switch (block.effect)
            {
                case BlockEffect.AOE:
                    Debug.Log($"Casted in {block.radius} radius!");
                    break;

                case BlockEffect.self:
                    Debug.Log("Casted to self!");
                    break;

                case BlockEffect.ally:
                    Debug.Log("Casted on Ally!");
                    break;

                case BlockEffect.enemy:
                    Debug.Log("Casted on Enemy!");
                    break;

                case BlockEffect.dmgBuff:
                    Debug.Log($"Buffs for {block.power} damage!");
                    break;

                case BlockEffect.armorBuff:
                    Debug.Log($"Buffs for {block.power} armor!");
                    break;

                case BlockEffect.moraleBuff:
                    Debug.Log($"Buffs for {block.power} morale!");
                    break;

                case BlockEffect.heal:
                    Debug.Log($"Heals for {block.power} HP!");
                    break;
            }
        }

        blocks.Clear();
        uimanager.HideAllPanels();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
