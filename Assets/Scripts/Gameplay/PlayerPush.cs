using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance=1f;

    public LayerMask boxMask;

    GameObject box;

    private Animator anim;

    private bool tocarSuelo;

    // Start is called before the first frame update
    void Start()
    {
        Joined = false;

        anim = GetComponent<Animator>();
    }
    public bool Joined { get; set; }
    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders=false;
        RaycastHit2D hit=Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, distance, boxMask);


        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.E) && !Joined && tocarSuelo)
        {
            Joined = true;
            box = hit.collider.gameObject;

            anim.SetBool("Grabing", true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && box != null) {
            Joined = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<Rigidbody2D>().isKinematic = true;
            box.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            anim.SetBool("Grabing", false);
        }

        if(Joined)
        {
            box.GetComponent<FixedJoint2D>().enabled=true;
            box.GetComponent<Rigidbody2D>().isKinematic = false;
            box.GetComponent<FixedJoint2D>().connectedBody=this.GetComponent<Rigidbody2D>();
        } 
        
    }


    void OnDrawGizmos()
    {
        Gizmos.color=Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position +Vector2.right*transform.localScale.x * distance);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            tocarSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            tocarSuelo = false;
        }
    }
}
