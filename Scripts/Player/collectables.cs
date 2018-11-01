using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour
{


    public BulletShooting scriptref;
    public bullettypes scriptref2;
    public cards cardSref;
    public cards1 cardrep1;
    public cards2 cardrep2;
     
    // Use this for initialization

    void Awake() {


        this.gameObject.GetComponent<BulletShooting>().istrue = false;

    }
    void Start()
    {
        scriptref = this.gameObject.GetComponent<BulletShooting>();
        scriptref2 = this.gameObject.GetComponent<bullettypes>();
        scriptref2.enabled = false;
        cardSref = FindObjectOfType<cards>();
        cardrep1 = FindObjectOfType<cards1>();
        cardrep2 = FindObjectOfType<cards2>();        

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "bc")          //bullets to collect
        {

            Destroy(GameObject.FindWithTag("bc"));
            this.gameObject.GetComponent<BulletShooting>().Ammo.value =+ 200;

           

        }


        else if (col.gameObject.tag == "bc1")  // bullets to collect type1
        {

            Destroy(GameObject.FindWithTag("bc1"));
            this.gameObject.GetComponent<BulletShooting>().Ammo.value = +200;
            this.gameObject.GetComponent<BulletShooting>().istrue = true;
           

        }

       else if (col.gameObject.tag == "bc2")   // bullets to collect type2 draw bullet
        {

            Destroy(GameObject.FindWithTag("bc2"));
            scriptref2.enabled = true;
            this.gameObject.GetComponent<BulletShooting>().Ammo.value = +200;



        }

        else if (col.gameObject.tag == "o")   // orbs to collect 1
        {

            Destroy(GameObject.FindWithTag("o"));

            cardrep1.GetComponent<cards1>().Orbs(true, false, false);
            cardrep2.GetComponent<cards2>().Power(true, false, false);
           
            



        }
        else if (col.gameObject.tag == "o1")   // orbs to collect 2
        {


            Destroy(GameObject.FindWithTag("o1"));
            cardrep1.GetComponent<cards1>().Orbs(false, true, false);
           cardrep2.GetComponent<cards2>().Power(false, true, false);
           

        }
       else if (col.gameObject.tag == "o2")   // orbs to collect 3
        {

            Destroy(GameObject.FindWithTag("o2"));

            cardrep1.GetComponent<cards1>().Orbs(false, false, true);
           cardrep2.GetComponent<cards2>().Power(false,false, true);
           

        }

        else if (col.gameObject.tag == "dk")  //drink to take 1
        {
            Destroy(GameObject.FindWithTag("dk"));

            cardSref.GetComponent<cards>().Drink(true, false, false);
           


        }

        else if (col.gameObject.tag == "dk1")  //drink to take 2
        {
            Destroy(GameObject.FindWithTag("dk1"));

            cardSref.GetComponent<cards>().Drink(false, true, false);
          
        }
        else if (col.gameObject.tag == "dk2")  //drink to take 3
        {

            Destroy(GameObject.FindWithTag("dk2"));

            cardSref.GetComponent<cards>().Drink(false, false, true);
           
        }
    }
}
