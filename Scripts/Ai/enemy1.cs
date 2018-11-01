using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour {

    public Transform target;
    public float Speed , bulletspeed;
    public float Stoppingdistiance;
    public float retreatdis;
    public Transform spawn;
    public int enemyh;
    public GameObject []Loot;
    public Transform spawnitems;
    public forallbullets forref;
    public exp refexp;
    public float timebtwshot, starttimebtwshots;
    public GameObject deathanim;
    public GameObject projectile;
    
    List<GameObject> bulletlist;
    // Use this for initialization
    void Start () {
        bulletlist = new List<GameObject>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        forref = FindObjectOfType<forallbullets>();
        refexp = FindObjectOfType<exp>();
        enemyh = 200;

        // obj pooling for enemy bullets//
        for (int i = 0; i < 3; i++)
        {

            var newbul = (GameObject)Instantiate(projectile);
            newbul.SetActive(false);
            bulletlist.Add(newbul);
        }



    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(target,Vector3.up);

        if (timebtwshot <= 0)
        {

            //  var newbullet = Instantiate(projectile, spawn.transform.position, spawn.transform.rotation);
            //newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * bulletspeed;

            for (int i = 0; i < bulletlist.Count; i++)
            {

                if (!bulletlist[i].activeInHierarchy)
                {


                    bulletlist[i].transform.position = spawn.position;
                    bulletlist[i].transform.rotation =  spawn.rotation;
                    bulletlist[i].SetActive(true);
                    bulletlist[i].GetComponent<Rigidbody>().velocity = bulletlist[i].transform.forward * bulletspeed;

                    break;


                }


            }


            timebtwshot = starttimebtwshots;
            soundmanager.PlaySound("shot");
            // Destroy(newbullet, 3.0f);

        }
        else
        {

            timebtwshot -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.L))
        {


            enemyh = -1;
        }
    }


    void OnCollisionEnter(Collision col) {

      
        if (col.gameObject.tag == "bullet") {
           
            refexp.GetComponent<exp>().expcount.value += 3;
             enemyh -=forref.amountofloss;

            GameObject.FindGameObjectWithTag("bullet").SetActive(false);
            if (enemyh < 0) {

                Destroy(this.gameObject);
                var newrep = Instantiate(deathanim, transform.position, transform.rotation);

                 Destroy(newrep, 3.0f);


              
                Instantiate(Loot[Random.Range(1, 3)] ,spawnitems.position , spawnitems.rotation);
                Instantiate(Loot[Random.Range(3, 6)] , spawnitems.position, spawnitems.rotation);
                print("this is health"+ enemyh);
             



            }




        }



    }
}
