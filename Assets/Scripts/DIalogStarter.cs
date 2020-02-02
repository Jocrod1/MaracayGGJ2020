using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIalogStarter : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager DM;

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
            DM.StartConversation(dialogue, gameObject);
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
