using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public Transform MainCam;  // Camera chính
    public Transform RoadBG;   // Đường hiện tại
    public Transform SideBG;   // Đường tiếp theo
    public float Length;       // Chiều dài mỗi đoạn đường

    void Update()
    {
        if (MainCam.position.z > RoadBG.position.z)
        {
            SpawnRoad(Vector3.forward); // Chạy đúng hướng Z
        }
    }

    void SpawnRoad(Vector3 direction)
    {
        SideBG.position = RoadBG.position + direction * Length; // Di chuyển đường lên trước
        (RoadBG, SideBG) = (SideBG, RoadBG); // Hoán đổi 2 đoạn đường
    }
}
