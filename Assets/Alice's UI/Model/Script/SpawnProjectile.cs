using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public Transform firePoint;
    public List<GameObject> vfx = new List<GameObject>();

    public RotateToMouse rotateToMouse;

    private GameObject effectToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SpawnVFX();
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if(firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.position, Quaternion.identity);
            if(rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.LogError("Missing Fire Point In The Inspector");
        }
    }
}
