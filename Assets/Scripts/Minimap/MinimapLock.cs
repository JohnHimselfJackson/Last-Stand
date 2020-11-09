using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapLock : MonoBehaviour
{
    public Transform playerT;
    public float zMax, zMin, xMax, xMin;
    public Vector3 midPoint;

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        float pX = playerT.position.x;
        float pY = playerT.position.y;
        float pZ = playerT.position.z;
        float newZ, newX;
        if (playerT.position.z < midPoint.z)
        {
            if (playerT.position.z > zMin)
            {
                newZ = Mathf.Lerp(transform.position.z,pZ,0.9f);
            }
            else
            {
                newZ = zMin;
            }
        }
        else
        {
            if (playerT.position.z < zMax)
            {
                newZ = Mathf.Lerp(transform.position.z, pZ, 0.9f);
            }
            else
            {
                newZ = zMax;
            }
        }

        if (playerT.position.x < midPoint.x)
        {
            if (playerT.position.x > xMin)
            {
                newX = Mathf.Lerp(transform.position.x, pX, 0.9f);
            }
            else
            {
                newX = xMin;
            }
        }
        else
        {
            if (playerT.position.x < xMax)
            {
                newX = Mathf.Lerp(transform.position.x, pX, 0.9f);
            }
            else
            {
                newX = xMax;
            }
        }
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }




}
