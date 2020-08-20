using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xMove = 0f;
    float yMove = 0f;
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        yMove = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

    }
    private void FixedUpdate()
    {
        this.transform.Translate(xMove, 0, yMove);
    }
}
