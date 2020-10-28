using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefabReferences : MonoBehaviour
{
    public static PlayerPrefabReferences PPR;
    private void Awake()
    {
        PPR = this;
    }
    public GameObject grenade;
    public GameObject laser;
}
