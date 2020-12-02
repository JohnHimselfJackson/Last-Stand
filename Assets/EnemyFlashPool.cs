using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlashPool : MonoBehaviour
{
    public static EnemyFlashPool flashPool;
    public GameObject toPool;
    public List<GameObject> objectPool;
    public int poolSize;


    private void Awake()
    {
        flashPool = this;
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
            obj.name = "FlashClone" + oo.ToString();
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
