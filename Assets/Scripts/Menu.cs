using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button again;
    public Button quit;
    public Button setting;
    public Button close;

    public GameObject ImageSetting;

    public void Start()
    {
        ImageSetting.SetActive(false);
        again.onClick.AddListener(Again);
        quit.onClick.AddListener(Quit);
        setting.onClick.AddListener(Setting);
        close.onClick.AddListener(Close);
    }

    public void Setting()
    {
        ImageSetting.SetActive(true);
        Time.timeScale = 0;
    }    
    public void Again()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void Close()
    {
        ImageSetting.SetActive(false);
        Time.timeScale = 1;
    }    

    public void Quit()
    {
        Application.Quit();
    }
}
