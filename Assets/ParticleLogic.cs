using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLogic : MonoBehaviour
{
    public void StartParticle(Vector3 particalPosition, float stayTime)
    {
        transform.position = particalPosition;
        gameObject.SetActive(true);
        Invoke("Inactive", stayTime);
    }
    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
