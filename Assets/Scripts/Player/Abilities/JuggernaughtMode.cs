using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuggernaughtMode : ActiveAbility
{
    void Awake()
    {
        stringName = "Juggernaught Mode";
        descritption = "Your armour plates shift to cover all weakspots at the expense of mobility";
        cooldown = 80;
        cooldownCount = 0;
    }

    public override void InvokeToRun()
    {
        print("called jugger");
        if (cooldownCount <= 0) AbilityStart();
    }

    void AbilityStart()
    {
        print("started jugger");
        PlayerManager.pM.pC.JuggernaughtChange(2,0.5f);
        PlayerManager.pM.JuggernaughtChange(6, 200,6);
        cooldownCount = cooldown;
        Invoke("AbilityEnd", 20);
    }

    void AbilityEnd()
    {
        PlayerManager.pM.pC.JuggernaughtChange(-2, -0.5f);
        PlayerManager.pM.JuggernaughtOver(6, 200, 6);
    }
}
