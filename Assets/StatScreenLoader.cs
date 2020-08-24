using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatScreenLoader : MonoBehaviour
{
    public static bool playerInZone;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }



}
