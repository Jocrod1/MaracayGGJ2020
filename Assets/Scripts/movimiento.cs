using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{

    public float speed = 5f;


    void Update()
    {

        //Movimiento horizontal
        float hInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(hInput * speed * Time.deltaTime, 0, 0);

    }
}
