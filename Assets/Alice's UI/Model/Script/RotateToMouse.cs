using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    public Camera cam;
    public float maximumLength;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    // Update is called once per frame
    void Update()
    {
        if(cam != null)
        {
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);

            if(Physics.Raycast(rayMouse.origin, rayMouse.direction, out RaycastHit hit, maximumLength))
            {
                RotateToMouseDirection(gameObject, hit.point);
            }
            else
            {
                pos = rayMouse.GetPoint(maximumLength);
                RotateToMouseDirection(gameObject, pos);
            }
        }
        else
        {
            Debug.LogError("There Is No Camera Set In The Inspector.");
        }
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.localRotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
