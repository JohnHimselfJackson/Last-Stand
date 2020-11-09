using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseThrusters : ActiveAbility
{
    void Awake()
    {
        stringName = "Impulse Thrusters";
        descritption = "Drastically increase you mobility";
        cooldown = 30;
        cooldownCount = 0;
    }

    public override void InvokeToRun()
    {
        print("called impulse");
        if(cooldownCount <= 0) AbilityStart();
    }

    void AbilityStart()
    {
        print("started impulse Thrusters");
        PlayerManager.pM.pC.ImpulseThusterChange(2, -0.4f, 1);
        cooldownCount = cooldown;
        Invoke("AbilityEnd", 10);
    }

    void AbilityEnd()
    {
        PlayerManager.pM.pC.ImpulseThusterChange(-2, 0.4f, -1);
    }




}
