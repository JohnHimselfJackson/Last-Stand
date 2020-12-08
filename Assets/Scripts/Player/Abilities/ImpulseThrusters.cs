using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

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
        EazySoundManager.PlaySound(PlayerPrefabReferences.PPR.abilityAudio, 0.2f, false, transform);
        PlayerManager.pM.pC.ImpulseThusterChange(2, -0.2f, 1);
        cooldownCount = cooldown;
        Invoke("AbilityEnd", 10);
    }

    void AbilityEnd()
    {
        EazySoundManager.PlaySound(PlayerPrefabReferences.PPR.abilityOverAudio, 0.2f, false, transform);
        PlayerManager.pM.pC.ImpulseThusterChange(-2, 0.2f, -1);
    }




}
