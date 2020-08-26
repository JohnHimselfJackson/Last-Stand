using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

public struct Firing : IComponentData {
    //bool isFiring;
    public float3 firePos;
}
