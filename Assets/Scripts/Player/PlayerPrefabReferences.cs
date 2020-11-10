using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class PlayerPrefabReferences : MonoBehaviour
{
    public static PlayerPrefabReferences PPR;
    private void Awake()
    {
        PPR = this;
    }
    public GameObject grenade;
    public GameObject shield;
    public GameObject laser;
    public AudioClip shotAudio;
    public void Start()
    {
        
    }
}
