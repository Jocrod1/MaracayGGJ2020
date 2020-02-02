using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDemo : MonoBehaviour
{

    Rigidbody2D Rb2D;

    // Start is called before the first frame update
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, 10);
        }
    }
}
