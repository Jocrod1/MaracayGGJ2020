using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    
    public bool presionado, palanca;

    private bool activado;

    private SpriteRenderer sprite;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


private void Update() {
    
    if(Input.GetKeyDown(KeyCode.E) && activado)
    {
        palanca=!palanca;

        presionado=true;
    }
    

    if(palanca==true)
    {
        sprite.color = Color.red;
    }
    else
    {
        sprite.color = Color.white;
    }
}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado=false;
        }
    }
    
}
