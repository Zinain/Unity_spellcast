using UnityEngine;

public enum BlockEffect { AOE, self, ally, enemy, dmgBuff, armorBuff, moraleBuff, heal };

[CreateAssetMenu(fileName = "PrayerBlock", menuName = "Scriptable Objects/PrayerBlock")]

public class PrayerBlock : ScriptableObject
{
    public string blockName;
    public BlockEffect effect;

}
