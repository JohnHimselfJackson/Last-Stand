using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMenuManager : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject upgradeCanvas;
    public GameObject statsCanvas;
    public GameObject upgradeGO;
    public GameObject upgradeBackground;
    public int gameState = 0; // 0 = stats menu, 1 = upgrade menu  


    public int movementStrength;

    private bool movingUp = false,
         movingDown = false,
         movingLeft = false,
         movingRight = false,
         draggingCamera = false;
    private Vector2 playerInput;
    private Vector3 mousePosition;
    private int camSizeMin = 3, camSizeMax = 30;

    private void Start()
    {
        // sets the game state to the stats menu
        upgradeBackground.SetActive(false);
        upgradeCanvas.SetActive(false);
        upgradeGO.SetActive(false);
        gameState = 0;
    }


    public void GoToUpgrades(BaseEventData data)
    {
        if (data.currentInputModule.input.GetMouseButtonDown(0))
        {
            upgradeBackground.SetActive(true);
            upgradeCanvas.SetActive(true);
            upgradeGO.SetActive(true);
            gameState = 1;
        }
    }

    public void BackToStats(BaseEventData data)
    {
        if (data.currentInputModule.input.GetMouseButtonDown(0))
        {
            upgradeBackground.SetActive(false);
            upgradeCanvas.SetActive(false);
            upgradeGO.SetActive(false);
            gameState = 0;
        }
    }

    private void Update()
    {
        CameraZoom();
        Movement();
        CameraDrag();
    }

    void CameraZoom()
    {
        float newcamsize = playerCamera.orthographicSize - Input.mouseScrollDelta.y;
        if (newcamsize > camSizeMin && newcamsize < camSizeMax)
        {
            playerCamera.orthographicSize -= Input.mouseScrollDelta.y;
        }
    }

    void Movement()
    {
        #region Getting Input
        if (Input.GetKeyDown(KeyCode.W))
        {
            movingUp = true;
            movingDown = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movingUp = false;
            movingDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            movingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingLeft = false;
            movingRight = true;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            movingUp = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movingDown = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }
        #endregion
        #region Sort Input
        playerInput = new Vector2(0, 0);
        if (movingUp)
        {
            playerInput += new Vector2(0, 1);
        }
        else if (movingDown)
        {
            playerInput += new Vector2(0, -1);
        }

        if (movingLeft & movingRight)
        {
            //does nothings
        }
        else if (movingLeft)
        {
            playerInput += new Vector2(-1, 0);
        }
        else if (movingRight)
        {
            playerInput += new Vector2(1, 0);
        }
        playerInput = playerInput.normalized;
        #endregion
        #region Moving
        GetComponent<Rigidbody2D>().velocity = playerInput * movementStrength;
        #endregion
    }

    void CameraDrag()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            draggingCamera = true;
            mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (draggingCamera)
        {
            transform.position += mousePosition - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        if ((Input.GetMouseButtonUp(1) && !Input.GetMouseButton(2)) || (Input.GetMouseButtonUp(2) && !Input.GetMouseButton(1)))
        {
            draggingCamera = false;
            mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    









}
