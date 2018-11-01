using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridmusic : MonoBehaviour {

    
    public Color a = new Color(0,0,0,0);
    public Color b;
    public audiovis audvis;
    float starttime;
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {

       
        audvis = FindObjectOfType<audiovis>();
        starttime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        Material mat = GetComponent<Renderer>().material;
        float t = (Mathf.Sin(Time.time - starttime)) * speed;
        // GetComponent<Renderer>().material.color = Color.Lerp(b,a, t);
        mat.SetColor("_EmissionColor" ,Color.Lerp(b,a,audvis.bgintensity) );
        print(audvis.averagesizevalue);
		
	}
}
