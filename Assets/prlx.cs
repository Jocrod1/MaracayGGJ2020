using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prlx : MonoBehaviour
{
/*    public Transform[] backgrounds;
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

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       for (int i = 0; i < backgrounds.Length; i++)
       {
          float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

          float backgroundTargetPosX = backgrounds[i].position.x + parallax;

          Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.x);

          backgrounds[i].position =  Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
       } 

      previousCamPos = cam.position; 
    }
    */
    [Tooltip("Aqui van los backgrounds y sus diferentes escalas")]
    public ParallaxElement[] Elements;
    public float Smoothing;

    public bool freezey, freezex;


    private Transform Came;
    private Vector3 PreviousCamPos;

	// Use this for initialization
	void Start () {

        Came = Camera.main.transform;

        PreviousCamPos = Came.position;

        Smoothing = -Smoothing;
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < Elements.Length; i++) {
            Vector3 Parallax = (PreviousCamPos - Came.position) * (Elements[i].ParallaxScale / Smoothing);

            float x, y, z;

            y = Elements[i].Background.position.y;
            x = Elements[i].Background.position.x;
            z = Elements[i].Background.position.z;

            if (!freezey)
                y += Parallax.y;

            if (!freezex)
                x += Parallax.x;

            Elements[i].Background.position = new Vector3(x, y, z);
        }
        PreviousCamPos = Came.position;

	}

    [System.Serializable]
    public struct ParallaxElement {
        public Transform Background;
        public float ParallaxScale;
    }
}
