using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform Player;
    public Transform spawnPoint; // Vị trí spawn
    public float spawnRate = 2f; // Tần suất spawn
    public float laneDistance = 2.5f; // Khoảng cách giữa các lane
    private float nextSpawnTime;

    private void Start()
    {
        //GameObject FoundPlayer = GameObject.FindWithTag("Player");
        //if (FoundPlayer != null )
        //{
        //    Player = FoundPlayer.transform;
        //}    
    }

    void Update()
    {

        if(Player == null) // Nếu chưa tìm thấy Player, tiếp tục tìm
        {
            GameObject foundPlayer = GameObject.FindWithTag("Player");
            if (foundPlayer != null)
            {
                Player = foundPlayer.transform;
            }
            return; // Chưa có player thì không spawn
        }

        if (Time.time >= nextSpawnTime)
        {
            SpawnObstacle();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObstacle()
    {
        for (int i = 0; i < 3; i++) // Spawn 3 vật cản cùng lúc
        {
            int randomLane = Random.Range(0, 3);
            Vector3 spawnPosition = new Vector3((randomLane - 1) * laneDistance, spawnPoint.position.y, Player.position.z + 70f + i * 5f);
            GameObject obstacle = ObstaclePool.instance.GetPool();
            if(obstacle != null )
            {
                obstacle.transform.position = spawnPosition;
                obstacle.SetActive(true);
            }
        }

    }
}
