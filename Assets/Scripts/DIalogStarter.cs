using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogStarter : MonoBehaviour
{
    public Dialogue dialogue;
    public GameManager GM;

    public bool heart1, heart2, heart3;

    public string eachone;

    BoxCollider2D Coll;

    public bool OnTrigger;
    // Start is called before the first frame update
    void Start()
    {
        Coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTrigger && Input.GetKeyDown(KeyCode.E)) {
            GM.SetMessagePanel("you have " + eachone + " of 3", dialogue);
            if (heart1)
                GM.heart1 = heart1;
            if (heart2)
                GM.heart2 = heart2;
            if (heart3)
                GM.heart3 = heart3;
            transform.parent.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OnTrigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OnTrigger = false;
        }
    }
}
