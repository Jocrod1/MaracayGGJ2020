using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColocarBateria : MonoBehaviour
{
    public GameObject bateria, camara, target, player;

    private BoxCollider2D BCD2;
    private Rigidbody2D RB2D;

    private FollowTarget follow;

    private bool animacion;

    public float timerTransicion;


    void Start()
    {
        BCD2= bateria.GetComponent<BoxCollider2D>();
        RB2D= bateria.GetComponent<Rigidbody2D>();

        follow=camara.GetComponent<FollowTarget>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Zona")
        {
            BCD2.enabled=false;
            RB2D.velocity= Vector3.zero;
            RB2D.isKinematic=true;

            animacion=true;
        }
    }


    void FixedUpdate()
    {
        if(animacion)
        {
            follow.target= target.transform;

            timerTransicion -= Time.deltaTime;

            if(timerTransicion <= 0.0f)
            {
                follow.target= player.transform;
            }
        }
    }





}
