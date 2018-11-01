using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class exp : MonoBehaviour
{



    public Slider expcount;
    public Text leveltext;
    public int levelcount;  // to exccess this in playmovement script
    public BulletShooting bulforpow;
    public Playermovement ply;
    public forallbullets bulexp;
    public int countexp = 0;
    public bool onexp= false;
     
    // Use this for initialization
    void Start()
    {

        levelcount = 0;
        bulexp.amountofloss = 10;
        ply = FindObjectOfType<Playermovement>();
        bulforpow = FindObjectOfType<BulletShooting>();
        bulexp = FindObjectOfType<forallbullets>();
        bulexp.amountofloss = 10;
         
}

    // Update is called once per frame
    void FixedUpdate()
    {

       // this is used for orbs cards // 
        if (onexp)
        {


            expcount.value++;

            if (expcount.value == 200)
            {

                countexp = countexp + 1;

            }

        }
        else {

            onexp = false;


        }

        //------------------------------------// 
        if (expcount.value == 200)
        {
            levelcount = levelcount + 1;
            leveltext.text = "" + levelcount;
            expcount.value = 0;
            expcount.value++;
            //ply.GetComponent<Playermovement>().nht = +20;
            // ply.GetComponent<Playermovement>().power.maxValue = +5;
            ply.GetComponent<Playermovement>().Speed++;
            if (ply.GetComponent<Playermovement>().Speed > 90)
            {

                ply.GetComponent<Playermovement>().Speed = 80;


            }

            bulforpow.GetComponent<BulletShooting>().ply.power.value = bulforpow.GetComponent<BulletShooting>().ply.power.value + 20 * 5;
            bulexp.amountofloss += 40;
            bulforpow.GetComponent<BulletShooting>().ply.health.value += 5;







        }
    }
}
