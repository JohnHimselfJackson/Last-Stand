using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiControl : MonoBehaviour
{
    //basic ui controller
    //not finsihed required more functionality

    public Toggle gridLineToggle; //whether the grid lines are shown or not
    public GameObject player; //player (start of path)
    public GameObject end; //end of path
    public LayerMask planeMask; //plane layer

    public Astar astar; //A* reference
    public Grid grid; //grid reference

    public GameObject goOne;
    public GameObject goTwo;

    bool goReady;
    bool rallyReady;
    public bool flareActive;

    GameObject initiateGO;
    public GameObject flare;

    public Transform RallyPoint;
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
        if (gridLineToggle.isOn == true)
        {

        }
    }
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
 
    public void Pathfind()
    {
        astar = GetComponent<Astar>();

        astar.FindPath(player.transform.position, end.transform.position);

    }
    public void SelectGameObjectOne()
    {
        initiateGO = goOne;
        goReady = true;
        rallyReady = false;
    }



    void Update()
    {

        
            if (Input.GetMouseButtonDown(0))
            {
            if (!rallyReady)
            {
                Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitme;
                if (Physics.Raycast(ray2, out hitme))
                {
                    if (hitme.collider.tag == "Building")
                    {
                        Debug.Log("Building Selected, Place Rally Point");
                        RallyPoint = hitme.transform.Find("rally");
                        rallyReady = true;
                    }
                }

            }
            else
            {
                Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitRally;
                if (Physics.Raycast(ray3, out hitRally))
                {
                    RallyPoint.position = hitRally.point;
                    rallyReady = false;
                }
            }                        
            }


        if (Input.GetMouseButtonDown(1))
        {
            Ray wayRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        if(Physics.Raycast(wayRay,out hit))
                {
                if (hit.collider.tag == "Plane")
                {
                    if (flareActive)
                    {
                        flare.transform.position = hit.point;
                        Debug.Log("new Flare");
                    }
                    else
                    {
                        Debug.Log("Flare Set");
                       flare =  Instantiate(flare, hit.point, Quaternion.identity);
                        flareActive = true;

                    }
                 

                }
                else { Debug.Log("cannot place flare"); }
          
                }
            
        }



        if (!Input.GetMouseButton(0))
            return;
        //if (!rallyReady)
        //{
            if (goReady)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    //check to see if building can be placed
                    if (grid.NodePoint(hit.point).isObstacle || grid.NodePoint(hit.point).isAgent || grid.NodePoint(hit.point).isBuilding)
                    {
                        Debug.Log("Cannot Place Here");
                        //MeshRenderer renderer = initiateGO.GetComponent<MeshRenderer>();
                        //Vector3 size = renderer.bounds.max;
                        //Debug.Log(size);
                    }
                    else
                    {
                        Instantiate(initiateGO, hit.point, Quaternion.identity);
                        goReady = false;
                        //Debug.Log("Now Place RallyPoint");

                    }

                }

                
            }
        //Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hitme;
        //if (Physics.Raycast(ray2, out hitme))
        //{
        //    GameObject rallyPoint = GameObject.Find("/Building/rally");
        //    rallyPoint.gameObject.transform.position = Vector3.zero;
        //   // rallyPoint.transform.position = hitme.point;

        //    rallyReady = true;
        //}
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
            
        //    Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitme;
        //    if (Physics.Raycast(ray2, out hitme))
        //    {
        //        if()
        //    }
        //}
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
