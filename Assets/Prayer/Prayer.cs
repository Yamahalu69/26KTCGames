using UnityEngine;
using UnityEngine.InputSystem;

public class Prayer : MonoBehaviour
{
    Vector2 inputVec;
    public float speed = 5;
    public float maxSpeed = 8;
    float nowSpeed = 0;
    Rigidbody2D rb;
    public float jumpPower = 8f;
    [Header("jumpPowerÇ∆ìØÇ∂êîíl")]
    public float jumpOriginal = 8f;
    public float jump = 0f;
    int number = 1;
    bool goJump = false;
    bool onGround = false;
    public LayerMask groundLayer;
    bool ingame = true;
    void OnMove(InputValue Value)
    {
        inputVec = Value.Get<Vector2>();
    }
    void OnJump(InputValue Value)
    {
        goJump = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ingame == true)
        {
            onGround = Physics2D.CircleCast(transform.position,
                                            0.2f,
                                            Vector2.down,
                                            0.15f,
                                            groundLayer);
            if ((onGround || inputVec.x != 0) && Input.GetKey(KeyCode.LeftShift))
            {
                
                rb.linearVelocity = new Vector2(inputVec.x * nowSpeed, rb.linearVelocity.y);
            }
            else if (onGround || inputVec.x != 0)
            {
                rb.linearVelocity = new Vector2(inputVec.x * speed, rb.linearVelocity.y);
            }
            if (inputVec.x > 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (inputVec.x < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            if (goJump && onGround)
            {
                jumpPower = jumpOriginal;
                number = 1;
            }
            if (goJump && number != 7)
            {
                if (number < 5)
                {
                    jump = jumpPower;
                    Vector2 v = new Vector2(0, jumpPower);
                    rb.AddForce(v, ForceMode2D.Impulse);
                }
                else
                {
                    Vector2 v = new Vector2(0, jump);
                    rb.AddForce(v, ForceMode2D.Impulse);
                }
                
                jumpPower = jumpPower * 0.66f;
                Debug.Log("ÉWÉÉÉìÉvâÒêîÇÕ" + number);
                goJump = false;
                number = number + 1;
            }
            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            ingame = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            ingame = false;
        }
    }

}

