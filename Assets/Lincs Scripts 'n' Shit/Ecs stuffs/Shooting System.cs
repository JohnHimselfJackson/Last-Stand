using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;


public class ShootingSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Firing fire, ref Translation trans) =>
        {
            float3 newDirc = fire.firePos - trans.Value;
            
            trans.Value += newDirc * Time.DeltaTime;
          
        });
    }
}

