using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    
    public bool palanca { get; private set; }

private void Update() {
    
    print(palanca);

}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                palanca=true;
            }
        }
    }
    
}
