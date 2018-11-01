using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doors : MonoBehaviour {


   // public GameObject[] obj;
    public GameObject stg1, stg2, stg3 , enemyspawn , enemyspawn2 , spawnaud;
    public audiovis audref;
    public Camerafollow cam;
   
    // Use this for initialization
    void Start() {

        audref = FindObjectOfType<audiovis>();

        cam = FindObjectOfType<Camerafollow>();
        // spawnaud.SetActive(false);  // final room audio spawn

    }

    // Update is called once per frame
    void Update() {


       

         
         

    }





    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "a") {

            print("a");
            Destroy(GameObject.FindGameObjectWithTag("a"));
            stg1.SetActive(true);



        }
        if (col.gameObject.tag == "b")
        {

            print("b");
            Destroy(GameObject.FindGameObjectWithTag("b"));
            stg2.SetActive(true);



        }
        if (col.gameObject.tag == "c")
        {

            Destroy(GameObject.FindGameObjectWithTag("c"));
            Destroy(GameObject.FindGameObjectWithTag("d"));


        }

        if (col.gameObject.tag == "f")
        {



            Destroy(GameObject.FindGameObjectWithTag("f"));
            audref.soruce.mute = false;
           
            stg3.SetActive(true);
            enemyspawn.SetActive(true);

        }

        if (col.gameObject.tag == "6")
        {



            Destroy(GameObject.FindGameObjectWithTag("6"));
            
            
            spawnaud.SetActive(true);
            enemyspawn2.SetActive(true);   // final room enemy spawn
            cam.GetComponent<Camerafollow>().offset.y = 364.7f;

        }

    }

     

    }
