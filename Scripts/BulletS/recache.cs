using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recache : MonoBehaviour {


    
    public Transform target;
    public float speed = 100.0f;
    public float Amplitude = 0;


    

    void Start() {



        GameObject myobj = GameObject.Find("target");
        target = myobj.GetComponent<Transform>();
        


    }




    // Use this for initialization
    void FixedUpdate() {

        //----sine wave for the bullets----//

        








        //--------------------------------//
        

        //var newspeed = newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * Speed;


        //newbullet.transform.position = Vector3.MoveTowards(bulletspawn.position,target.position, Time.deltaTime);


        

        if (transform.position != target.position)
        {

            

            Vector3 pos = Vector3.MoveTowards(transform.position , target.position  , speed * Time.deltaTime);


            GetComponent<Rigidbody>().MovePosition(pos);

           


        }
        Debug.Log("inupdate");


    }

   
}
