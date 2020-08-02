using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    //basic ui controller
    //not finsihed required more functionality

    public InputField widthField; //width of map
    public InputField heightField; //height of map
    public Toggle gridLineToggle; //whether the grid lines are shown or not
    public GameObject player; //player (start of path)
    public GameObject end; //end of path
    public LayerMask planeMask; //plane layer

    public Astar astar; //A* reference
    public Grid grid; //grid reference

    public GameObject goOne;
    public GameObject goTwo;

    bool goReady;

    GameObject initiateGO;

    public void CreateGridButton()
    {
        if(gridLineToggle.isOn == true){
            Debug.Log("Gridlines on");
        }

        grid.GetComponent<Grid>();

        grid.GridCreation();
       
    }

    public void GridLines()
    {
        if(gridLineToggle.isOn ==true)
        {

        }    }
    public void PlaceStartPoint()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, planeMask))
        {
            player.transform.position = hit.point;
        }
       
    }
    public void PlaceBuilding()
    {
        initiateGO = goOne;
        goReady = true;
    }
    public void PlaceEndPoint()
    {

    }
    public void Pathfind()
    {
        astar = GetComponent<Astar>();

        astar.FindPath(player.transform.position, end.transform.position);
        Debug.Log("brfgbb");
    }
    public void SelectGameObjectOne()
    {
        initiateGO = goOne;
        goReady = true;
    }



    void Update()
    {

        if (!Input.GetMouseButton(0))
            return;
        if (goReady)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(initiateGO, hit.point, Quaternion.identity);
                goReady = false;
            }
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
