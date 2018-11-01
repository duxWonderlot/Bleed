using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class use : MonoBehaviour {


    public Playermovement playermov;
    public setactive setsonic;
    public BulletShooting bullscropt;
    public bullettypes drawpowref;
    public exp expref;
    public bool blue = false, green= false, violet= false;



    void Start() {


         setsonic = FindObjectOfType<setactive>();
        bullscropt = FindObjectOfType<BulletShooting>();
        playermov = FindObjectOfType<Playermovement>();
        drawpowref = FindObjectOfType<bullettypes>();
        expref = FindObjectOfType<exp>(); 

    }


    void Update() {

        print("expcounter" + expref.countexp);
        print("onexp" + expref.onexp);

        if (expref.onexp == true)
        {


            expref.onexp = true;
            //expref.GetComponent<exp>().countexp = 0;
            if (expref.GetComponent<exp>().countexp >= 3 && green == true)   // green orb
            {

                expref.onexp = false;
                expref.GetComponent<exp>().countexp = 0;
                blue = false;
                violet = false;

            }


            if (expref.GetComponent<exp>().countexp >= 1 && blue == true)   // blue orb
            {

                expref.onexp = false;
                expref.GetComponent<exp>().countexp = 0;
                violet = false;
                green = false;


            }


            if (expref.GetComponent<exp>().countexp >= 5 && violet == true)  // violent orb rare
            {

                expref.onexp = false;
                expref.GetComponent<exp>().countexp = 0;
                green = false;
                blue = false;

            }
        }



    }
    void OnTriggerEnter(Collider col) {
         
        if (col.gameObject.tag == "uidk") {


            GameObject.FindWithTag("uidk").SetActive(false);
            print("is in1");
            playermov.GetComponent<Playermovement>().health.value = 30;
            Destroy(GameObject.FindWithTag("uidk"));
            
        }

        if (col.gameObject.tag == "uidk1")
        {
            GameObject.FindWithTag("uidk1").SetActive(false);
            print("is in2");
            playermov.GetComponent<Playermovement>().health.value = 100;
          

        }

        if (col.gameObject.tag == "uidk2")
        {
            GameObject.FindWithTag("uidk2").SetActive(false);
            print("is in3");
            playermov.GetComponent<Playermovement>().health.value = 500;
           

        }

        if (col.gameObject.tag == "uiorb1")  // green orb
        {

            GameObject.FindWithTag("uiorb1").SetActive(false);
            expref.onexp = true;
            green = true;

        }

        if (col.gameObject.tag == "uiorb2")   // blue orb
        {
            GameObject.FindWithTag("uiorb2").SetActive(false);
            expref.onexp = true;
            blue = true;

        }

        if (col.gameObject.tag == "uiorb3")  // violent orb rare
        {

            GameObject.FindWithTag("uiorb3").SetActive(false);
            expref.onexp = true;
            violet = true;


        }
        // these cards will not destory

        if (col.gameObject.tag == "uipow1")
        {

            setsonic.GetComponent<setactive>().setact = true;
            print("inpow1");

        }

        if (col.gameObject.tag == "uipow2")
        {

            bullscropt.GetComponent<BulletShooting>().setactive = true;
            print("inpow2");
        }

        if (col.gameObject.tag == "uipow3")
        {

            drawpowref.GetComponent<bullettypes>().setactive = true;
            print("inpow3");
        }



    }
}
