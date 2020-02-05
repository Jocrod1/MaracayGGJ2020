using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensor : MonoBehaviour
{
    public GameObject corazon, player, target, parteCorazon1, parteCorazon2, parteCorazon3, puerta;

    private bool activado, activado2;

    public float velocidad;

    private TriggerRobot triggerParte1, triggerParte2, triggerParte3;

    private BoxCollider2D BC2DPuerta;

    private Player scriptPlayer;

    private Animator animPj;

    // Start is called before the first frame update
    void Start()
    {
        scriptPlayer = player.GetComponent<Player>();
        animPj=player.GetComponent<Animator>();

        triggerParte1= parteCorazon1.GetComponent<TriggerRobot>();
        triggerParte2= parteCorazon2.GetComponent<TriggerRobot>();
        triggerParte3= parteCorazon3.GetComponent<TriggerRobot>();

        BC2DPuerta= puerta.GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(activado && triggerParte1.puesto==true && triggerParte2.puesto==true && triggerParte3.puesto==true)
        {
            if(this.transform.position.y!=target.transform.position.y)
            {
                BC2DPuerta.isTrigger=false;
                
                animPj.SetBool("Grounded", true);
                animPj.SetFloat("Speed", 0.0f);
                

                scriptPlayer.enabled = false;
                scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                float velocidad_nueva = velocidad * Time.deltaTime;
                this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, velocidad_nueva);
                
            }
            else if(this.transform.position.y==target.transform.position.y)
            {
                scriptPlayer.enabled = true;
                activado=false;
            }
        }

    }
}
