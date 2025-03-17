using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float SpeedPlayer;
    public float MoveSpeed; 
    public Joystick Joystick;
    public float JumpFoce = 10f;
    private bool IsGround = true;  
    Rigidbody rb;
    Animator ani;



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


    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * SpeedPlayer * Time.deltaTime);
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
            ani.SetTrigger("IsJump");
            ani.SetBool("IsGround", false);
            rb.angularVelocity = new Vector3 (rb.angularVelocity.x,JumpFoce,rb.angularVelocity.z);
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            GameManeger.Instance.AddScore(10);
        }
    }
}
