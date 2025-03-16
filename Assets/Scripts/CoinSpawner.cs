using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Transform Road;
    public int coinCount;
    private PlayerController player;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(SpawnCoinsRepeatedly());
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        foreach (GameObject coin in ObjectPool.Instance.pool)
        {
            if (coin.activeInHierarchy && coin.transform.position.z < player.transform.position.z - 10f)
            {
                coin.SetActive(false); // Ẩn coin nếu nó tụt lại phía sau Player
            }
        }
    }

    IEnumerator SpawnCoinsRepeatedly()
    {
        while (true)
        {
            coinCount = Random.Range(3, 10);
            int randomPattern = Random.Range(0, 3);
            SpawnCoin(randomPattern);
            yield return new WaitForSeconds(15f);
        }
    }

    public void SpawnCoin(int pattern)
    {
        float baseZ = Road.position.z + Random.Range(10, 50);

        switch (pattern)
        {
            case 0: // Hàng dọc
                for (int i = 0; i < coinCount; i++)
                {
                    Vector3 spawnPos = new Vector3(Random.Range(-4.8f, 4.4f), 1, baseZ + i * 1.5f);
                    SpawnFromPool(spawnPos);
                }
                break;

            case 1: // Hàng ngang
                for (int i = 0; i < coinCount; i++)
                {
                    Vector3 spawnPos = new Vector3(-4.8f + i * 1.5f, 1, baseZ);
                    SpawnFromPool(spawnPos);
                }
                break;

            case 2: // Zig-zag
                for (int i = 0; i < coinCount; i++)
                {
                    float xOffset = (i % 2 == 0) ? -2.5f : 2.5f;
                    Vector3 spawnPos = new Vector3(xOffset, 1, baseZ + i * 1.5f);
                    SpawnFromPool(spawnPos);
                }
                break;
        }
    }

    void SpawnFromPool(Vector3 position)
    {
        GameObject coin = ObjectPool.Instance.GetPooledObject();
        if (coin != null)
        {
            coin.transform.position = position;
            coin.SetActive(true);
        }
    }
}
