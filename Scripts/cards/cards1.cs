using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cards1 : MonoBehaviour {

    public GameObject[] drink;

    public GameObject[] power;

    public GameObject[] orbs;

    private int cardcount = 0;
    private bool ishere = false;
     
    // public  Transform parent;


    //public int index;


    // Use this for initialization
    void Start() {



    }

    // Update is called once per frame

    // should instantiate only one of 3 cards from the stack
    // and should spawn in catain locations
    void FixedUpdate() {



    }


    public void Drink(bool tookdrnk1 , bool drink2 , bool drink3) {

        if (tookdrnk1)
        {

            Instantiate(drink[Random.Range(0, 4)], transform.parent);
            tookdrnk1 = false;


        }

        if (drink2)
        {

            Instantiate(drink[Random.Range(1, 4)], transform.parent);

            drink2 = false;
        }
        if (drink3)
        {

            Instantiate(drink[Random.Range(2, 4)], transform.parent);

            drink3 = false;
        }



    }
    public void Power(bool tokpow1 , bool tokpow2 , bool tokepow3) {

        if (tokpow1)
        {

            Instantiate(power[Random.Range(0, 4)], transform.parent);
            tokpow1 = false;

        }

        if (tokpow2)
        {

            Instantiate(power[Random.Range(1, 4)], transform.parent);
            tokpow2 = false;

        }
        if (tokepow3)
        {

            Instantiate(power[Random.Range(2, 4)], transform.parent);
            tokepow3 = false;

        }


    }
    public void Orbs(bool tookorb1 , bool tookorb2 , bool tookorb3) {

        if (tookorb1) {

            Instantiate(orbs[Random.Range(0, 4)], transform.parent);

            tookorb1 = false;

        }


        if (tookorb2) {


            Instantiate(orbs[Random.Range(1, 4)], transform.parent);
            tookorb2 = false;
        }

        if (tookorb3) {

            Instantiate(orbs[Random.Range(2,4)], transform.parent);
            tookorb3 = false;

        }


    } 


    /*
    void OnCollisionEnter(Collision col) {

        if (col.gameObject.tag == "dk")
        {


            Instantiate(drink[Random.Range(0, 4)], transform.parent);

            Destroy(GameObject.FindWithTag("dk"));


        }
        else if (col.gameObject.tag == "dk1")
        {


            Instantiate(drink[Random.Range(1, 4)], transform.parent);
            Destroy(GameObject.FindWithTag("dk1"));
        }
        else if (col.gameObject.tag == "dk2") {

            Instantiate(drink[Random.Range(2, 4)], transform.parent);
            Destroy(GameObject.FindWithTag("dk2"));

        }


    }
    */
}
