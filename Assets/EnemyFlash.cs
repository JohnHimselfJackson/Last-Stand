using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
    public void StartParticle(Vector3 particalPosition, float stayTime, float size)
    {
        GetComponent<ParticleSystem>().Play();
        transform.position = particalPosition;
        transform.localScale = new Vector3(size, size, size);
        gameObject.SetActive(true);
        Invoke("Inactive", stayTime);
    }
    void Inactive()
    {
        gameObject.SetActive(false);
    }
}
