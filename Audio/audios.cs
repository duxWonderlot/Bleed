using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour {


    public AudioSource audiomanager;
    public AudioClip bgm ;
    






	// Use this for initialization
	void Start () {
        this.audiomanager = GetComponent<AudioSource>();
       

    }
	
	// Update is called once per frame
	void Update () {


         
        


        if (Input.GetKeyDown(KeyCode.E))
        {


             
          //  audiomanager.clip = bgm; 
           // audiomanager.mute = true;

          



        }
        else if (Input.GetKeyUp(KeyCode.E)) {

           
 
            

        
           // audiomanager.clip = bgm;
           // audiomanager.mute = false;
       

        }
      


    }
}
