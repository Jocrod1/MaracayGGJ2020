using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prlx : MonoBehaviour
{
    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;
    private Transform cam;
    private Vector3 previousCamPos;

    void awake()
    {
        cam = Camera.main.transform;
    }
    void Start()
    {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.lenght];

        for (int i = 0; i < backgrounds.length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       for (int i = 0; i < backgrounds.length; i++)
       {
          float parallax = (previousCamPos - Cam.position.x) * parallaxScales[i];

          float backgroundTargetPosX = backgrounds[i].position.x + parallax;

          Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.x);

          backgrounds[i].position =  Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
       } 

      previousCamPos = cam.position; 
    }
}
