using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBateria : MonoBehaviour
{
    public GameObject bateria, camara, target, player, grua, objgrua;

    private BoxCollider2D BCD2;
    private Rigidbody2D RB2D;

    private FollowTarget follow;

    private Player scriptPlayer;
    private PlayerPush push;

    private bool animacion;

    private Animator anim;

    public float timerTransicion, timerGrua, velocidad;


    void Start()
    {
        BCD2= bateria.GetComponent<BoxCollider2D>();
        RB2D= bateria.GetComponent<Rigidbody2D>();

        scriptPlayer = player.GetComponent<Player>();

        follow =camara.GetComponent<FollowTarget>();

        push = player.GetComponent<PlayerPush>();

        anim= player.GetComponent<Animator>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zona")
        {
            RB2D.velocity= Vector3.zero;
            RB2D.isKinematic=true;

            BCD2.enabled=false;

            push.Joined = false;
            bateria.GetComponent<FixedJoint2D>().enabled = false;
            collision.gameObject.SetActive(false);

            bateria.transform.position= new Vector3(-9.3f, -0.36f, 5f);

            animacion=true;
        }
    }


    void FixedUpdate()
    {
        if(animacion)
        {
            anim.SetBool("Grabing", false);
            anim.SetFloat("Speed", 0.0f);
            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            follow.target= target.transform;

            timerTransicion -= Time.deltaTime;
            timerGrua -= Time.deltaTime;

            //la grua subiendo
            if(timerGrua <=0.0f)
            {
                float velocidad_nueva = velocidad * Time.deltaTime;

                grua.transform.position = Vector3.MoveTowards(grua.transform.position, objgrua.transform.position, velocidad_nueva);
            }

            if (timerTransicion <= 0.0f)
            {
                follow.target= player.transform;
                scriptPlayer.enabled = true;
                animacion = false;
            }
        }
    }





}
