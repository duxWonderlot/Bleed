using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enespawner : MonoBehaviour {



    public GameObject[] enemy;

    public float timebtwspawn, starttimebtxspawn;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (timebtwspawn <= 0)
        {

            var newbullet = Instantiate(enemy[Random.Range(0,3)], transform.position, transform.rotation);
            
            timebtwspawn = starttimebtxspawn;

          

        }
        else
        {

            timebtwspawn -= Time.deltaTime;
        }






    }
}
