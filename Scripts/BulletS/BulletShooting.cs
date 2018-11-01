using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class BulletShooting : MonoBehaviour {


    // this script is spawning and moving bullets
    //you have to drag and drop the objects to reference
    //this script also counts total no of default bullets of player


    public GameObject bulletprefab , bulletpowder;
    public Transform bulletspwan , powdertrans;
    public int Speed ,bulletcount;
    public GameObject bulletpfs;
    public Slider Ammo;
    public bool istrue = false , setactive = false;
    public Playermovement ply;
    List<GameObject> bulletlist;
    

    //-----------time var------------//

    public timemanger time;
    //-----------------------//

    private float timeCount;



    void Awake() {

        bulletlist = new List<GameObject>();

        //Ammo.value = 200;
        setactive = false;
      
        ply = FindObjectOfType<Playermovement>();

        for (int i = 0; i < 20; i++) {

            var newbul = (GameObject)Instantiate(bulletprefab);
            newbul.SetActive(false);
            bulletlist.Add(newbul);            
        }
         

    }

    
 

    void FixedUpdate() {

          

        if (setactive)     // doughtfull about this 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {




                ply.power.value--;
                ply.Speed = 120.0f;
                time.DoSlowmotion(0.1f);                    // slowstime which is called from other script 





            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {

                ply.Speed = 80.0f;
                time.DoSlowmotion(1.0f);




            }

            if (ply.power.value == 0) {

                ply.Speed = 80.0f;
                time.DoSlowmotion(1.0f);

            }
            

        }



        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

           

            if (Ammo.value != 0)
            {
                soundmanager.PlaySound("shot");
                fire(true);
                Ammo.value = Ammo.value - 2;
                Debug.Log(Ammo.value);
               

                if (Ammo.value == 0)
                {
                    fire(false);


                    print("no ammo");
                }
            }

            



        }
        else {


            fire(false);
            

        }

        if (istrue)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {

                Ammo.value = Ammo.value - 10;
                fire2(true);

                if (Ammo.value == 0) {

                    istrue = false;
                    print("no ammo");
                }
            }
            else if (Input.GetKeyUp(KeyCode.Mouse2))
            {


                fire2(false);


            }
        }









    }

    void fire(bool isSpawn) {


       

        if (isSpawn == true)
        {

            for (int i = 0; i < bulletlist.Count; i++) {

                if (!bulletlist[i].activeInHierarchy) {

                    
                    bulletlist[i].transform.position = bulletspwan.position;
                    bulletlist[i].transform.rotation = bulletspwan.rotation;
                    bulletlist[i].SetActive(true);
                    bulletlist[i].GetComponent<Rigidbody>().velocity = bulletlist[i].transform.forward * Speed;
                     
                    break;


                }


            }
            
            
            /*
            var newbullet = (GameObject)Instantiate(bulletprefab, bulletspwan.position, bulletspwan.rotation);
            var sparks = (GameObject)Instantiate(bulletpowder,powdertrans.position, powdertrans.rotation);

            newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * Speed;
            sparks.GetComponent<Rigidbody>().velocity = sparks.transform.forward;


            Destroy(newbullet, 3.0f);
            Destroy(sparks , 2.0f);
            */
        }

    }

   public void fire2(bool isSpawn)   // do not delete ,this is a different bullet type
    {

        if (isSpawn == true)
        {
           // refernobj.GetComponent<setactive>().isTrue = true;
            var newbullets = Instantiate(bulletpfs, bulletspwan.position, bulletspwan.rotation);
            bulletcount += 1;
            Destroy(newbullets , 20.0f);
            ///settan.enabled = !settan.enabled;
            Debug.Log("Spawnspb");

            if (bulletcount > 10 ) {

               // refernobj.GetComponent<setactive>().isTrue = false;
                isSpawn = false;

                Debug.Log("Spawnspb (False)");

            }

            Destroy(newbullets, 2.0f);
        }

    }



 





}
