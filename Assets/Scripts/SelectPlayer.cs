using Unity.Cinemachine;
using UnityEngine;

public class SelectPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] Characters;
    private int index;
    private GameObject PlayerInstance;
    public CinemachineCamera Camera;

    void Start()
    {
        index = PlayerPrefs.GetInt("SelectedCharacter", 0);

        for (int i = 0; i < Characters.Length; i++)
        {
            Characters[i].SetActive(i == index);
        }

        PlayerInstance = Instantiate(Characters[index], new Vector3(0,0,-95), Quaternion.identity);
        Camera.LookAt = PlayerInstance.transform;
        Camera.Follow = PlayerInstance.transform;
       
    }

   
}
