using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    int collisionLayer = (1 << 8) | (1 << 10) | (1 << 11) | (1 << 12) | (1 << 13);
    private void OnCollisionEnter(Collision collision)
    {
        print("grenage collision" + collision.gameObject.name + collision.gameObject.layer);
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            Explode();
        }
    }
    void Explode()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Destroy(gameObject, 0.4f);
    }
}
