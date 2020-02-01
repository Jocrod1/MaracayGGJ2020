using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    
    public bool tocarCaja { get; private set; }
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if (tocarCaja)
        {
            this.rb2d.isKinematic=false;
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        
        } else
        {
            
            rb2d.velocity = new Vector2(0, 0);

            this.rb2d.isKinematic=true;
        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tocarCaja=true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            tocarCaja=false;
        }
    }
    
}
