using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    
    public bool presionado, palanca;

    private bool activado;

    private Animator anim;
    
    void Start()
    {

        anim = GetComponent<Animator>();
    }


private void Update() {
    
    if(Input.GetKeyDown(KeyCode.E) && activado)
    {
        palanca=!palanca;

        presionado=true;
    }

    anim.SetBool("Activado", palanca);
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
