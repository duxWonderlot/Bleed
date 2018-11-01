using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiostop : MonoBehaviour {



   public AudioSource audio;

	// Use this for initialization
	void Start () {


        this.audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E)) {


            audio.Play();

        }

		
	}
}
