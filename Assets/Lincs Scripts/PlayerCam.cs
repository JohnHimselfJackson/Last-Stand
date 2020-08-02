using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
    // This script functions as a way for the main game camera to follow the player at a certain height
{
    public GameObject playerCam;//a reference to the player\
    public int height = 45;//height of the cam above the player
    float xMove = 0f;
    float yMove = 0f;
    float speed = 10f;

    private void Update()//every update moves the camera to the players position and height varible
    {
       // playerCam = GameObject.FindGameObjectWithTag("Player");//reference for the cam to find the player
        this.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y +height, playerCam.transform.position.z);//moving the cam to be locked on to the player
      //  xMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
     //   yMove = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {
      //  playerCam.transform.Translate(xMove, 0, yMove);
    }//
}
