using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timemanger : MonoBehaviour {
     
   // public float Solowfactor = 0.03f;  not in use
    public float SlowLenght = 2f;

   // public GameObject obj;
 
	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
       
	}

    public void DoSlowmotion(float Slowfacetor) {


        Time.timeScale = Slowfacetor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        

    }
}
