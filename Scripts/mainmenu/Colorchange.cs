using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchange : MonoBehaviour {


    public Camera cam;
    public Color color1 ,color2;
    float starttime;
    public float speed = 1.0f;
    public bool repeat = false;
	// Use this for initialization
	void Start () {

        starttime = Time.time;
        cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        cam = Camera.main;
        if (!repeat)
        {
            float t = (Time.time - starttime) * speed;
            cam.backgroundColor = Color.Lerp(color1, color2, t);
        }
        else {


            float t = (Mathf.Sin(Time.time - starttime) * speed);
            cam.backgroundColor = Color.Lerp(color1, color2, t);

        }
		
	}
}
