using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettypes : MonoBehaviour
{  

    // this is draw bullet script

    public GameObject bulletfabs;
    public Transform bulletspawn;
    public bool setactive = false;
   // public Transform target;
    //public int Speed =10;
    

    // Use this for initialization
    void Start()
    {
        //bullet = transform.position;
        setactive = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (setactive)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {

                
                var newbullet = (GameObject)Instantiate(bulletfabs, bulletspawn.position, bulletspawn.rotation);


                //var newspeed = newbullet.GetComponent<Rigidbody>().velocity = newbullet.transform.forward * Speed;


                //newbullet.transform.position = Vector3.MoveTowards(bulletspawn.position,target.position, Time.deltaTime);


                Destroy(newbullet, 3.0f);






            }
        }

    
    }

}
