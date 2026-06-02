using UnityEngine;
using UnityEngine.InputSystem;

public class Prayer : MonoBehaviour
{
    Vector2 inputVec;
    public float speed = 3;
    Rigidbody2D rb;
    public float jumpPower = 8f;
    [Header("jumpPowerと同じ数値")]
    public float jumpOriginal = 8;
    public float jump = 0f;
    bool goJump = false;
    public float jump_altitude = 0.66f;
    [Header("ジャンプ回数やjunp_altitudeにより変える")]
    public float ccc = 1.002f;
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
            int number = 1;
            onGround = Physics2D.CircleCast(transform.position,
                                            0.2f,
                                            Vector2.down,
                                            0.15f,
                                            groundLayer);
            if (onGround || inputVec.x != 0)
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
            if (goJump && jumpPower > ccc)
            {
                if (number < 5)
                {
                    jump = jumpPower;
                    Vector2 v = new Vector2(0, jumpPower);
                    rb.AddForce(v, ForceMode2D.Impulse);
                }
                if (number > 4)
                {
                    Vector2 v = new Vector2(0, jump);
                    rb.AddForce(v, ForceMode2D.Impulse);
                }
                
                jumpPower = jumpPower * jump_altitude;
                Debug.Log("ジャンプ回数は" + number);
                goJump = false;
                number = number + 1;
            }
            else if (onGround)
            {
                jumpPower = jumpOriginal;
                number = 1;
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

