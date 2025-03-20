using UnityEngine;

public class MusicManeger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static MusicManeger instance;

    public AudioSource BgMusic;
    public AudioSource SfxMusic;

    public AudioClip CoinClip;
    public AudioClip GameOverClip;
    public AudioClip JumpClip;
    public AudioClip RunClip;
    public AudioClip BgClip;

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
    }

    public void SfxCoin()
    {
        SfxMusic.PlayOneShot(CoinClip);
    }    

    public void SfxJump()
    {
        SfxMusic.PlayOneShot(JumpClip);
    }    

    public void SfxRun()
    {
        SfxMusic.PlayOneShot(RunClip);
    }    

    public void SfxGameOver()
    {
        SfxMusic.PlayOneShot(GameOverClip);
    }    
}
