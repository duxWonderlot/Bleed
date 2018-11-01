using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybul : MonoBehaviour {


     
	// Use this for initialization
	void Start () {

 
	}
	
	// Update is called once per frame
	void Update () {


        Destroy(this.gameObject , 0.7f);
    }


    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "Player") {

            Destryprojectile();

        }

    }

    void Destryprojectile() {

        Destroy(this.gameObject);

    }
}
