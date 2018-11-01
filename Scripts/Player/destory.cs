using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour {

    void OnCollisionEnter(Collision coli) {

        if (coli.gameObject.tag == "bend") {


            Destroy(coli.gameObject);



        }




    }
}
