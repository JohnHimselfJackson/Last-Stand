using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed, fireRate;

    public GameObject muzzlePF, hitPF;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
        if(muzzlePF != null)
        {
            var muzzleVFX = Instantiate(muzzlePF, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.LogError("Speed Value Is Missing In The Inspector");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];

        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(hitPF != null)
        {
            Instantiate(hitPF, pos, rot);
        }
        Destroy(gameObject);
    }
}
