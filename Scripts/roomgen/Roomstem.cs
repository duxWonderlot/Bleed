using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomstem : MonoBehaviour {

    public int Openingdirection;



    private MapGen roomtemp;
    private int rand;
    private bool spawned = false;




    void Start() {

        roomtemp = GameObject.FindGameObjectWithTag("rooms").GetComponent<MapGen>();

        Invoke("Spawn", 0.5f);


    }



    void Spawn() {


if (spawned == false) {


            if (Openingdirection == 1)
            {

                rand = Random.Range(0, roomtemp.bottomroom.Length);

                Instantiate(roomtemp.bottomroom[rand], transform.position, Quaternion.identity);


            }
            else if (Openingdirection == 2)
            {

                rand = Random.Range(0, roomtemp.toproom.Length);

                Instantiate(roomtemp.toproom[rand], transform.position, Quaternion.identity);


            }
            else if (Openingdirection == 3)
            {
              rand = Random.Range(0, roomtemp.leftroom.Length);

                Instantiate(roomtemp.leftroom[rand], transform.position, Quaternion.identity);


            }
            else if (Openingdirection == 4) {

                rand = Random.Range(0, roomtemp.rightroom.Length);

                Instantiate(roomtemp.rightroom[rand], transform.position, Quaternion.identity);

         }


            spawned = true;

        }




      


    }


    void OnTriggerEnter(Collider other) {



        if(other.CompareTag("spp")){

            Destroy(gameObject);


        }




    }


}
