using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRobot : MonoBehaviour
{

    public GameObject player, target, parteCorazon, camara, targetRobot;

    private bool activado;
        
    public float velocidad;

    private Player scriptPlayer;

    private FollowTarget follow;

    private Animator animPj;

    public bool puesto;


    void Start()
    {
        scriptPlayer = player.GetComponent<Player>();
        animPj=player.GetComponent<Animator>();
        follow =camara.GetComponent<FollowTarget>();
    }



    void FixedUpdate()
    {
        if(activado)
        {
            animPj.SetFloat("Speed", 0.0f);
                
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            scriptPlayer.enabled = false;
 

            float velocidad_nueva = velocidad * Time.deltaTime;
            parteCorazon.transform.position = Vector3.MoveTowards(parteCorazon.transform.position, target.transform.position, velocidad_nueva);

            follow.target= targetRobot.transform;


            if(parteCorazon.transform.position==target.transform.position)
            {
                follow.target= player.transform;
                scriptPlayer.enabled = true;
                activado=false;
                puesto=true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            activado = true;
        }
    }
}
