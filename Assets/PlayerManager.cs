using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager pM;
    public PlayerController pC;

    private void Awake()
    {
        pC = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        pC.SetOnLoad(PlayerData.playerStats);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayer()
    {

    }


}
