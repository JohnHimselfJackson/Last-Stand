using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitOvercharge : ActiveAbility
{
    void Awake()
    {
        stringName = "Suit Overcharge";
        descritption = "Overcharge all the artifical muscles and thrusters drastically increasing speed for a very short time";
        cooldown = 80;
        cooldownCount = 0;
    }

    public override void InvokeToRun()
    {
        print("called over");
        if (cooldownCount <= 0) AbilityStart();
    }

    void AbilityStart()
    {
        print("started over");
        PlayerManager.pM.pC.OverchargeChange(3, -0.3f, 1);
        PlayerManager.pM.OverchargeChange(12,15);
        cooldownCount = cooldown;
        Invoke("AbilityEnd", 5);
    }

    void AbilityEnd()
    {
        PlayerManager.pM.pC.OverchargeChange(-3, 0.3f, -1);
        PlayerManager.pM.OverchargeOver(12, 15);
    }
}
