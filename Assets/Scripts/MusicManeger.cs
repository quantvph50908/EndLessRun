using UnityEngine;
using UnityEngine.UI;

public class MusicManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static MusicManeger instance;

    public AudioSource BgMusic;
    public AudioSource SfxMusic;

    public AudioClip CoinClip;
    public AudioClip GameOverClip;
    public AudioClip JumpClip;
    public AudioClip BgClip;

    public Slider BGVolume;
    public Slider SFXVolume;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }    
        else
        {
            Destroy(gameObject);
        }    
    }
    void Start()
    {
        BgMusic.clip = BgClip;
        BgMusic.loop = true;
        BgMusic.Play();


        float SaveBGVolume = PlayerPrefs.GetFloat("BG", 1);
        float SaveSfxVolume = PlayerPrefs.GetFloat("Sfx", 1);

        SetBG(SaveBGVolume);
        SetSfx(SaveSfxVolume);

        if(BGVolume != null)
        {
            BGVolume.value = SaveBGVolume;
            BGVolume.onValueChanged.AddListener(SetBG);
        }    

        if(SFXVolume != null)
        {
            SFXVolume.value = SaveSfxVolume;
            SFXVolume.onValueChanged.AddListener(SetSfx);
        }


    }

    public void SetBG(float volume)
    {
        Debug.Log(volume);
        BgMusic.volume = volume;
        PlayerPrefs.SetFloat("BG", volume);
        PlayerPrefs.Save();
    }    

    public void SetSfx(float volume)
    {
        SfxMusic.volume = volume;
        PlayerPrefs.SetFloat("Sfx",volume);
        PlayerPrefs.Save();
    }    

    public void SfxCoin()
    {
        SfxMusic.PlayOneShot(CoinClip);
    }    

    public void SfxJump()
    {
        SfxMusic.PlayOneShot(JumpClip);
    }    

    public void SfxGameOver()
    {
        SfxMusic.PlayOneShot(GameOverClip);
    }    
}
