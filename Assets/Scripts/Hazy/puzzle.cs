using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject palanca1, palanca2, palanca3, palanca4, palanca5, puerta, target, player, camara, targetVista;

    public Animator anim1, anim2, anim3, anim4, anim5;

    private FollowTarget follow;
    
    private Player scriptPlayer;

    private trigger trigger1,trigger2,trigger3,trigger4,trigger5; 

    private bool activarPuerta;

    public float velocidad, timer, timerMovimiento, ShakeDuration, ShakeMagnitude;



    // Start is called before the first frame update
    void Start()
    {
        trigger1=palanca1.GetComponent<trigger>();
        trigger2=palanca2.GetComponent<trigger>();
        trigger3=palanca3.GetComponent<trigger>();
        trigger4=palanca4.GetComponent<trigger>();
        trigger5=palanca5.GetComponent<trigger>();

        anim1=palanca1.GetComponent<Animator>();
        anim2=palanca2.GetComponent<Animator>();
        anim3=palanca3.GetComponent<Animator>();
        anim4=palanca4.GetComponent<Animator>();
        anim5=palanca5.GetComponent<Animator>();

        scriptPlayer = player.GetComponent<Player>();
        follow =camara.GetComponent<FollowTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(trigger1.presionado)
        {
            trigger2.palanca= !trigger2.palanca;

            trigger1.presionado=false;
        }
        if(trigger2.presionado)
        {
            trigger1.palanca=!trigger1.palanca;
            trigger3.palanca=!trigger3.palanca;

            trigger2.presionado=false;
        }
        if(trigger3.presionado)
        {
            trigger2.palanca=!trigger2.palanca;
            trigger4.palanca=!trigger4.palanca;

            trigger3.presionado=false;
        }
        if(trigger4.presionado)
        {
            trigger3.palanca=!trigger3.palanca;
            trigger5.palanca=!trigger5.palanca;

            trigger4.presionado=false;
        }
        if(trigger5.presionado)
        {
            trigger4.palanca=!trigger4.palanca;

            trigger5.presionado=false;
        }


        if(trigger1.palanca && trigger2.palanca && trigger3.palanca && trigger4.palanca && trigger5.palanca)
        {
            anim1.SetBool("Activado", true);
            anim2.SetBool("Activado", true);
            anim3.SetBool("Activado", true);
            anim4.SetBool("Activado", true);
            anim5.SetBool("Activado", true);

            trigger1.enabled=false;
            trigger2.enabled=false;
            trigger3.enabled=false;
            trigger4.enabled=false;
            trigger5.enabled=false;

            scriptPlayer.enabled = false;
            scriptPlayer.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            follow.target= targetVista.transform;

            timer -= Time.deltaTime;
            timerMovimiento -= Time.deltaTime;

            float velocidad_nueva = velocidad * Time.deltaTime;
            puerta.transform.position = Vector3.MoveTowards(puerta.transform.position, target.transform.position, velocidad_nueva);

            if (timerMovimiento <= 0.0f)
            {
                follow.gameObject.GetComponent<FollowTarget>().GetDamage(ShakeDuration, ShakeMagnitude, 0,0);
            }

            if (timer <= 0.0f)
            {
                trigger1.palanca=false;
                trigger2.palanca=false;
                trigger3.palanca=false;
                trigger4.palanca=false;
                trigger5.palanca=false;

                follow.target= player.transform;
                scriptPlayer.enabled = true;
            }
        }
        
    }
}
