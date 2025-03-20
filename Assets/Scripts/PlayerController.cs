using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float SpeedPlayer;
    public float MoveSpeed; 
    public Joystick Joystick;
    public float JumpFoce;
    private bool IsGround = true;  
    Rigidbody rb;
    Animator ani;
    public GameObject ImageOver; 



    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    [System.Obsolete]
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(Joystick == null)
        {
            Joystick = FindObjectOfType<Joystick>();
        }

        

        if(ImageOver == null)
        {
            ImageOver = GameObject.Find("Over");
        }

        if(ImageOver != null)
        {
            ImageOver.SetActive(false);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.forward * SpeedPlayer * Time.deltaTime);
        MusicManeger.instance.SfxRun();
        CheckRoad();
    }

    void CheckRoad()
    {
        float Horizontal = Joystick.Horizontal;
        
        float NewX = transform.position.x + Horizontal * MoveSpeed * Time.deltaTime;

        NewX = Mathf.Clamp(NewX, -7f, 7f);

        transform.position = Vector3.Lerp(transform.position,new Vector3(NewX,transform.position.y,transform.position.z), Time.deltaTime * 20);
    }

    public void Jump()
    {
        if (IsGround)
        {
            MusicManeger.instance.SfxJump();
            ani.SetTrigger("IsJump");
            ani.SetBool("IsGround", false);
            rb.AddForce(Vector3.up * JumpFoce,ForceMode.Impulse);
            IsGround = false;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
            Debug.Log("a");
            ani.SetBool("IsGround", true);
        }  
        
        if(collision.gameObject.CompareTag("Ban"))
        {
            MusicManeger.instance.SfxGameOver();
            ImageOver.SetActive(true);
            Time.timeScale = 0;
        }    
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            MusicManeger.instance.SfxCoin();
            other.gameObject.SetActive(false);
            GameManeger.Instance.AddScore(10);
        }
    }
}
