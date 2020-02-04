using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject robot, corazon, camara, player, target;

    private FollowTarget follow;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        if(animacion)
        {
            animPj.SetBool("Grabing", false);
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
        if (collision.gameObject.tag == "Pushable")
        {
            collision.gameObject.SetActive(false);
            animacion=true;
        }
    }


}
