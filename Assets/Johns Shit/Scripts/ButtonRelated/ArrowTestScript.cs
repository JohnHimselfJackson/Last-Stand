using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTestScript : MonoBehaviour
{
    public GameObject me;
    public GameObject pointTo;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        GameObject startButton = me;
        GameObject endButton = pointTo;
        float length = (endButton.transform.position - startButton.transform.position).magnitude;
        Vector3 midpoint = new Vector3((endButton.transform.position.x - startButton.transform.position.x) / 2, (endButton.transform.position.y - startButton.transform.position.y) / 2, (endButton.transform.position.z - startButton.transform.position.z) / 2);
        print(midpoint + " is the midpoint of " + endButton + " and " + startButton);
        print("angle is " + (Mathf.Atan2(startButton.transform.position.y - endButton.transform.position.y, startButton.transform.position.x - endButton.transform.position.x)* Mathf.Rad2Deg - 180));
        GameObject prereqArrow = Instantiate<GameObject>(arrow, midpoint, Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(startButton.transform.position.y - endButton.transform.position.y, startButton.transform.position.x - endButton.transform.position.x) * Mathf.Rad2Deg - 180)));
        prereqArrow.transform.SetParent(this.transform);
        prereqArrow.transform.localScale = new Vector3((length / prereqArrow.GetComponent<SpriteRenderer>().bounds.size.x)*0.8f, 1, 1);
        prereqArrow.transform.position = midpoint;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
