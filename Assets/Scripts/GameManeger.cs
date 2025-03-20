using TMPro;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameManeger Instance;
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextHighScoreText;
    private int Score = 0;
    private int HighScore = 0;

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

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        TextHighScoreText.text = "High Score: " +  HighScore.ToString();
    }
    public void AddScore(int add)
    {
        Score += add;
        TextScore.text = Score.ToString();

        if(Score > HighScore)
        {
            HighScore = Score;
            TextHighScoreText.text = "High Score: " + HighScore.ToString();
            PlayerPrefs.SetInt("HighScore", HighScore);
            PlayerPrefs.Save();
        }    
    }    
}
