using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{

    //private CharacterController charector;
  
    private float verticalvelocity = -400.0f;
   
    private Physics phymana;
     
    //private float jumpforce =10.0f;
    void Start()
    {


        Vector3 movevector = new Vector3(0, -1000.0f, 0);
        Physics.gravity = movevector;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 movevector = new Vector3(0, verticalvelocity, 0);
        Physics.gravity = movevector;



    }

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "ground") {
            print("isenter");
            verticalvelocity = -9.8f;
            
        }


    }

    void OnTriggerStay(Collider col)
    {

        if (col.gameObject.tag == "ground")
        {
            print("isenter");
            verticalvelocity = -9.8f;
        }


    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "ground")
        {

            print("isexit");
            verticalvelocity -= 10040.0f;


        }


    }


}
