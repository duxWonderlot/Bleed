using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class guid : MonoBehaviour
{

    public Text gud;

    void Start()
    {

        gud.text = "";
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "2") {

            gud.text = "these are collectables for drink can be used from inventory, they give you health when used";


        }
        if (col.gameObject.tag == "3")
        {

            gud.text = "these are collectables for orbs can be used from inventory , they give you different types of cards according to color";


        }
        if (col.gameObject.tag == "1")
        {

            gud.text = "these are collectables for bullet you can use any bullet type for refilling bullets,"+"\n"+ "there are different types of bullet like draw bullet , bend bullet , normal bullet";
           

        }

        if (col.gameObject.tag == "4")
        {

            gud.text = "\n" + "there are cards in your inventory you have to drag then drop in 'Use' to use them ," + "\n" + "fusion cell to create new cards like combining power cards + drink cards ," + "\n" + " these new cards can give you  +ve or -ve impact to player ," + "\n" + " So choose wisely!";
            

        }
        if (col.gameObject.tag == "5")
        {

            gud.text = "you can hide UI by pressing SPACEBAR" + "\n" + "W,A,S,D are movement , left , middle , right mouse buttons are different bullet types(can be unlock before use) to shoot" + "\n" + "key Q is bullet time and Key E is divert bullets these can be used from you inventory if you get it" + "\n" + "Your level matters before you fight an enemy";
             
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "1")
        {

            gud.text = " ";


        }
        if (col.gameObject.tag == "2")
        {

            gud.text = " ";


        }
        if (col.gameObject.tag == "3")
        {

            gud.text = " ";
            gud.text = " ";

        }
        if (col.gameObject.tag == "4")
        {

            gud.text = " ";
            gud.text = " ";

        }
        if (col.gameObject.tag == "5")
        {

            gud.text = " ";
            gud.text = " ";

        }

    }
}
