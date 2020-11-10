﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : ActiveAbility
{
    int relectionCount;
    GameObject shieldPrefab;
    GameObject shieldInstance;

    void Awake()
    {
        stringName = "Shield Generator";
        descritption = "create a temporary reflective shield ";
        cooldown = 40;
        cooldownCount = 0;
    }
    private void Start()
    {
        shieldPrefab = PlayerPrefabReferences.PPR.shield;
    }

    public override void InvokeToRun()
    {
        print("called shield");
        if (cooldownCount <= 0) AbilityStart();
    }

    void AbilityStart()
    {
        print("started shield");
        shieldInstance = Instantiate(shieldPrefab, transform);
        cooldownCount = cooldown;
        Invoke("AbilityEnd", 10);
    }

    void AbilityEnd()
    {
        Destroy(shieldInstance);
    }
}
