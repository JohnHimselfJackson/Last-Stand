using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new upgrade", menuName = "Upgrades")]
public class UpgradeScriptable : ScriptableObject
{
    public bool upgraded;
    public enum type { stats, passive, active, multi }
    public type myType;

    public string name { get; private set; }
    public void SetName(string newName)
    {
        name = newName;
    }

    public string description { get; private set; }
    public void SetDescription(string newDescription)
    {
        description = newDescription;
    }

    public float[][] statChanges { get; private set; }
    public void SetStatChanges(float[][] newStatChanges)
    {
        statChanges = newStatChanges;
    }

    public ActiveAbility aA;
    public PassiveAbility pA;
}
