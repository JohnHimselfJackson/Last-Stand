using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class ExplosionLogic : MonoBehaviour
{
    public AudioClip explosionNoise;
    public void BeginExplosion(Vector3 particalPosition, float size)
    {
        EazySoundManager.PlaySound(explosionNoise, 10f ,false,transform);
        GetComponent<ParticleSystem>().Play();
        transform.position = particalPosition;
        gameObject.SetActive(true);
        transform.localScale = new Vector3(size, size, size);
        Invoke("Inactive", 4);

    }
    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
