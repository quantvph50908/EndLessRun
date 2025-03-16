using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManeger Instance;
    public TextMeshProUGUI TextScore;
    private int Score = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }    
    }
    public void AddScore(int add)
    {
        Score += add;
        TextScore.text = Score.ToString();
    }    
}
