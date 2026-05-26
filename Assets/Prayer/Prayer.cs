using Unity.VisualScripting;
using UnityEngine;

public class Prayer : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    public float jump = 1;
    public float jamp_altitude = 0.66f;
    bool invincible = false;
    bool dead = false;
    bool clear = false;
    bool ingame = true;
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
            float x = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(x * speed, 0);

            if (jump == 1)
            {
                invincible = true;
            }
            else if (jump < 1)
            {
                invincible = false;
            }

        }
        if (dead == true)
        {
            ingame = false;
        }
        if (clear  == true)
        {
            ingame = false;
        }
    }
    void FixedUpdate()
    {
        if (ingame == true)
        {
            
        }
        
    }
}
