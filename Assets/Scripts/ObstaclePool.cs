using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public static ObstaclePool instance;
    public GameObject PrefabsObstacle;
    public int PoolSize = 20;
    private List<GameObject> pool;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }    
        pool = new List<GameObject>();
    }

    private void Start()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject Obj = Instantiate(PrefabsObstacle);
            Obj.SetActive(false);
            pool.Add(Obj);
        }
    }

    public GameObject GetPool()
    {
        foreach (var item in pool)
        {
            if(!item.activeInHierarchy)
            {
                return item;
            }    
        }

        GameObject NewObj = Instantiate(PrefabsObstacle);
        NewObj.SetActive(false);
        pool.Add(NewObj);
        return NewObj;
    }    

}
