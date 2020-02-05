using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject robot, parteCorazon1, parteCorazon2, parteCorazon3, camara, player, target;

    private FollowTarget follow;

    private TriggerRobot triggerParte1, triggerParte2, triggerParte3;

    private Animator anim, animPj;

    public float timerTransicion;

    private Player scriptPlayer;

    private bool animacion;

    void Start()
    {
        anim= robot.GetComponent<Animator>();
        animPj= player.GetComponent<Animator>();
        follow =camara.GetComponent<FollowTarget>();
        scriptPlayer = player.GetComponent<Player>();

        triggerParte1= parteCorazon1.GetComponent<TriggerRobot>();
        triggerParte2= parteCorazon2.GetComponent<TriggerRobot>();
        triggerParte3= parteCorazon3.GetComponent<TriggerRobot>();
    }


    void FixedUpdate()
    {
        if(animacion && triggerParte1.puesto==true && triggerParte2.puesto==true && triggerParte3.puesto==true)
        {
            animPj.SetFloat("Speed", 0.0f);
            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            follow.target= target.transform;

            anim.SetBool("dying", true);

            timerTransicion -= Time.deltaTime;

            if (timerTransicion <= 0.0f)
            {
                follow.target= player.transform;
                scriptPlayer.enabled = true;
                animacion = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animacion=true;
        }
    }


}
