using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button again;
    public Button quit;

    public void Start()
    {
        again.onClick.AddListener(Again);
        quit.onClick.AddListener(Quit);
    }
    public void Again()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
