using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {

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

    public GameObject projectile;
    
    // Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        forref = FindObjectOfType<forallbullets>();
        enemyh = 200;
        refexp = FindObjectOfType<exp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > Stoppingdistiance)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

        }
        else if (Vector3.Distance(transform.position, target.position) < Stoppingdistiance && Vector3.Distance(transform.position, target.position) > retreatdis)
        {

            transform.position = this.transform.position;


        }
        else if (Vector3.Distance(transform.position, target.position) < retreatdis)
        {



            transform.position = Vector3.MoveTowards(transform.position, target.position, -Speed * Time.deltaTime);

        }

        transform.LookAt(target, new Vector3(0, transform.position.y, 0));

        if (timebtwshot <= 0)
        {

            var newbullet = Instantiate(projectile, spawn.transform.position, spawn.transform.rotation);
            newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * bulletspeed;
            timebtwshot = starttimebtwshots;

            Destroy(newbullet, 3.0f);

        }
        else
        {

            timebtwshot -= Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.K))
        {


            enemyh = -1;
        }
    }


    void OnCollisionEnter(Collision col) {


      

        if (col.gameObject.tag == "bullet") {

            refexp.GetComponent<exp>().expcount.value += 3;
            enemyh -= forref.amountofloss;

            GameObject.FindGameObjectWithTag("bullet").SetActive(false);
            if (enemyh < 0) {

                Instantiate(Loot[Random.Range(1, 3)] ,spawnitems.position , spawnitems.rotation);
                Instantiate(Loot[Random.Range(3, 6)] , spawnitems.position, spawnitems.rotation);
                print("this is health"+ enemyh);
               
                Destroy(this.gameObject);

               
            }




        }



    }
}
