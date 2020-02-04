using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensor : MonoBehaviour
{
    public GameObject corazon, player, target, target2;

    private bool activado, activado2;

    public float velocidad;

    private Player scriptPlayer;

    private Animator animPj;

    // Start is called before the first frame update
    void Start()
    {
        scriptPlayer = player.GetComponent<Player>();
        animPj=player.GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pushable")
        {
            activado = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(activado)
        {
            if(this.transform.position.y!=target.transform.position.y)
            {
                animPj.SetBool("Grabing", false);
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
