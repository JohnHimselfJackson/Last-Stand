using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ParticleLogic : MonoBehaviour
{
    public AudioClip mySound;
    public void StartParticle(Vector3 particalPosition, float stayTime)
    {
        if(mySound != null)
        {
            EazySoundManager.PlaySound(mySound, 0.4f, false, transform);
        }
        GetComponent<ParticleSystem>().Play();
        transform.position = particalPosition;
        gameObject.SetActive(true);
        Invoke("Inactive", stayTime);
    }
    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
