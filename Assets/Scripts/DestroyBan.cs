using UnityEngine;

public class DestroyBan : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && transform.position.z < player.position.z - 10f)
        {
            gameObject.SetActive(false);    
        }
    }
}
