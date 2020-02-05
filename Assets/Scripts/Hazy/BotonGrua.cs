using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGrua : MonoBehaviour
{
    public GameObject grua, camara, player, panel, target;

    private Rigidbody2D RB2D;

    private bool activado, activado2;

    private FollowTarget follow;

    private Player scriptPlayer;

    private BoxCollider2D BC2D;

    public float timer;

    private Animator anim;

    public float ShakeMagnitude, ShakeDuration;


    void Start()
    {
        RB2D = grua.GetComponent<Rigidbody2D>();

        follow = camara.GetComponent<FollowTarget>();

        scriptPlayer = player.GetComponent<Player>();

        anim= player.GetComponent<Animator>();

        BC2D= GetComponent<BoxCollider2D>();

        auxtimer = timer;
    }


    float auxtimer;
    private void FixedUpdate()
    {
        if (activado2)
        {
            anim.SetBool("Grabing", false);
            anim.SetFloat("Speed", 0.0f);
            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            BC2D.enabled=false;

            if (timer == auxtimer) {
                RB2D.isKinematic = false;
                Destroy(RB2D.gameObject, 3f);
            }
            
            timer -= Time.deltaTime;

            follow.target= target.transform;

            if (timer <= 0.0f)
            {
                follow.gameObject.GetComponent<FollowTarget>().GetDamage(ShakeDuration, ShakeMagnitude, 0,0);
                scriptPlayer.enabled = true;
                panel.SetActive(false);
                activado2 = false;

                follow.target= player.transform;
            }
        }
    }

    private void Update()
    {
        if(activado && Input.GetKeyDown(KeyCode.E))
        {
            activado2 = true;
            activado = false;

            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
