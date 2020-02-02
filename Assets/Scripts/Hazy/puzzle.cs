using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject palanca1, palanca2, palanca3, palanca4, palanca5;

    private trigger trigger1,trigger2,trigger3,trigger4,trigger5; 


    // Start is called before the first frame update
    void Start()
    {
        trigger1=palanca1.GetComponent<trigger>();
        trigger2=palanca2.GetComponent<trigger>();
        trigger3=palanca3.GetComponent<trigger>();
        trigger4=palanca4.GetComponent<trigger>();
        trigger5=palanca5.GetComponent<trigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(trigger1.presionado)
        {
            trigger2.palanca= !trigger2.palanca;

            trigger1.presionado=false;
        }
        if(trigger2.presionado)
        {
            trigger1.palanca=!trigger1.palanca;
            trigger3.palanca=!trigger3.palanca;

            trigger2.presionado=false;
        }
        if(trigger3.presionado)
        {
            trigger2.palanca=!trigger2.palanca;
            trigger4.palanca=!trigger4.palanca;

            trigger3.presionado=false;
        }
        if(trigger4.presionado)
        {
            trigger3.palanca=!trigger3.palanca;
            trigger5.palanca=!trigger5.palanca;

            trigger4.presionado=false;
        }
        if(trigger5.presionado)
        {
            trigger4.palanca=!trigger4.palanca;

            trigger5.presionado=false;
        }
        
    }
}
