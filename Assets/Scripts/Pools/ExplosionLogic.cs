using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionLogic : MonoBehaviour
{
    public void BeginExplosion(Vector3 particalPosition, float size)
    {
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
