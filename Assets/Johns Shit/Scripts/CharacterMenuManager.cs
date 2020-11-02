using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
    private Vector3 mouseStartPosition;
    private int camSizeMin = 3, camSizeMax = 10;

    private void Start()
    {
        // sets the game state to the stats menu
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));

        //sets stats view

        upgradeBackground.SetActive(false);
        upgradeCanvas.SetActive(false);
        upgradeGO.SetActive(false);
        gameState = 0;
        playerCamera.orthographicSize = 6;
        transform.position = new Vector3(0, -20, 0);

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
            playerCamera.orthographicSize = 6;
            transform.position = new Vector3(0, -20, 0);
        }
    }

    private void Update()
    {
        if (upgradeBackground.activeInHierarchy)
        {
            CameraZoom();
            Movement();
            CameraDrag();
        }
    }

    void CameraZoom()
    {
        float newcamsize = playerCamera.orthographicSize - Input.mouseScrollDelta.y;
        if (newcamsize > camSizeMin && newcamsize < camSizeMax)
        {
            playerCamera.orthographicSize -= Input.mouseScrollDelta.y;
        }
    }

    //returns movement direction as vector 3
    Vector3 GetDirection()
    {
        Vector3 returnThis = Vector3.zero;

        //gets keys down and sets values true/false according
        if (Input.GetKeyDown(KeyCode.W))
        {
            movingUp = true;
            movingDown = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movingDown = true;
            movingUp = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
            movingLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            movingRight = false;
        }

        //sets values to false on key up
        if (Input.GetKeyUp(KeyCode.W))
        {
            movingUp = false;
            if (Input.GetKey(KeyCode.S))
            {
                movingDown = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            movingDown = false;
            if (Input.GetKey(KeyCode.W))
            {
                movingUp = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
            if (Input.GetKey(KeyCode.A))
            {
                movingLeft = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
            if (Input.GetKey(KeyCode.D))
            {
                movingRight = true;
            }
        }

        if (movingUp)
        {
            returnThis += transform.forward;
        }
        if (movingDown)
        {
            returnThis -= transform.forward;
        }
        if (movingRight)
        {
            returnThis += transform.right;
        }
        if (movingLeft)
        {
            returnThis -= transform.right;
        }
        returnThis = returnThis.normalized;
        return returnThis;
    }
    void Movement()
    {
        #region Moving
        playerCamera.transform.position += (GetDirection() * movementStrength);
        #endregion
    }

    void CameraDrag()
    {

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            draggingCamera = true;
            mouseStartPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (draggingCamera)
        {
            transform.position -= mouseStartPosition - playerCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseStartPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        if ((Input.GetMouseButtonUp(1) && !Input.GetMouseButton(2)) || (Input.GetMouseButtonUp(2) && !Input.GetMouseButton(1)))
        {
            draggingCamera = false;
            mouseStartPosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void BackToGame()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(2));
        PlayerManager.pM.pC.cam.gameObject.SetActive(true);
        PlayerManager.pM.LoadPlayer();
    }
    public void BeginGame()
    {
        SceneManager.LoadScene("scxcZ");
        PlayerManager.pM.LoadPlayer();
    }








}
