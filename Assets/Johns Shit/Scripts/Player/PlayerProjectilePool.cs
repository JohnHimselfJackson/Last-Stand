using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilePool : MonoBehaviour
{
    public static PlayerProjectilePool playerPool;
    public GameObject toPool;
    public List<GameObject> objectPool;
    public int poolSize;


    private void Awake()
    {
        playerPool = this;
    }

    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        objectPool = new List<GameObject>();
        for(int oo = 0; oo < poolSize; oo++)
        {
            GameObject obj = Instantiate(toPool);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for(int oo = 0; oo < objectPool.Count; oo++)
        {
            if (!objectPool[oo].activeInHierarchy)
            {
                return objectPool[oo];
            }
        }
        return null;
    }






}
