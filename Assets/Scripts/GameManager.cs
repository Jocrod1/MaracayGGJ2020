using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject MessagePanel;
    public Text messagetext;

    public bool heart1, heart2, heart3;

    public GameObject gHeart1, gHeart2, gHeart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gHeart1.SetActive(heart1);
        gHeart2.SetActive(heart2);
        gHeart3.SetActive(heart3);
    }

    public void SetMessagePanel(string message, Dialogue fordialogue)
    {
        MessagePanel.SetActive(true);
        messagetext.text = message;
        MessagePanel.GetComponent<messageManager>().fordialoguing = fordialogue;
    }
}
