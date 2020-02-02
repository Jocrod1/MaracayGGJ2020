using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageManager : MonoBehaviour
{
    public Dialogue fordialoguing;
    public DialogueManager DM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableOnanimation() {
        DM.StartConversation(fordialoguing);
        gameObject.SetActive(false);
    }
}
