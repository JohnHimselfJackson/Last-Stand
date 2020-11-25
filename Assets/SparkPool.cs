using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkPool : MonoBehaviour
{
    public static SparkPool sparkPool;
    public GameObject toPool;
    public List<GameObject> objectPool;
    public int poolSize;


    private void Awake()
    {
        sparkPool = this;
    }

    void Start()
    {
        CreatePool();
    }

    void CreatePool()
    {
        objectPool = new List<GameObject>();
        for (int oo = 0; oo < poolSize; oo++)
        {
            GameObject obj = Instantiate(toPool);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int oo = 0; oo < objectPool.Count; oo++)
        {
            if (!objectPool[oo].activeInHierarchy)
            {
                objectPool[oo].SetActive(true);
                return objectPool[oo];
            }
        }
        return null;
    }
}
