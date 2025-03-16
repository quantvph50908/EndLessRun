using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject prefab;
    public int poolSize = 20;
    public List<GameObject> pool;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        // Nếu hết object, tạo thêm nhưng giới hạn số lượng
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
