using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonGrua : MonoBehaviour
{
    public GameObject grua;

    private Rigidbody2D RB2D;

    private bool activado;


    void Start()
    {
        RB2D = grua.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
          if (Input.GetKeyDown(KeyCode.E) && activado)
          {
                RB2D.isKinematic = false;
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
