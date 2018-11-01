using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusioncell : MonoBehaviour {

    public List<GameObject> arrayofobj;
    public GameObject sonicC, bultimeC, drawC , orbB ,orbV , orbG;
    public Transform objref;
    public bool istrue = false , istrue2 = false , istrue3 =true;
    // Use this for initialization
    void Start () {
        arrayofobj = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {

         

   


    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "uipow1")
        {

            // sonic card

            arrayofobj.Add(sonicC);
            istrue = true;

        }

        if (col.gameObject.tag == "uipow2")
        {

            //bullet time card

            arrayofobj.Add(bultimeC);
            istrue2 = true;

        }

        if (col.gameObject.tag == "uipow3")
        {

            //draw bul card

            arrayofobj.Add(drawC);
            istrue3 = true;

        }

        if (istrue2 == true  && istrue == true || istrue == true && istrue2 == true)
        {

            print("combined!");
            Instantiate(orbB , transform.parent);
            Destroy(GameObject.FindGameObjectWithTag("uipow1"));
            Destroy(GameObject.FindGameObjectWithTag("uipow2"));


        }


        if (istrue == true && istrue2 == true && istrue3 == true || istrue3 == true && istrue2 == true && istrue == true || istrue2 == true && istrue3 == true && istrue == true)
        {

            print("combined!");
            Instantiate(orbV, transform.parent);
            Destroy(GameObject.FindGameObjectWithTag("uipow2"));
            Destroy(GameObject.FindGameObjectWithTag("uipow3"));
            Destroy(GameObject.FindGameObjectWithTag("uipow1"));


        }

        if (istrue2 == true && istrue3 == true || istrue3 == true && istrue2 == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("uipow2"));
            Destroy(GameObject.FindGameObjectWithTag("uipow3"));
            print("combined!");
            Instantiate(orbG, transform.parent);


        }



    }
     



    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "uipow1")
        {

            // sonic card

            arrayofobj.Remove(sonicC);
            istrue = false;

        }

        if (col.gameObject.tag == "uipow2")
        {

            //bullet time card

            arrayofobj.Remove(bultimeC);
            istrue2 = false;

        }

        if (col.gameObject.tag == "uipow3")
        {

            //draw bul card

            arrayofobj.Remove(drawC);

        }
    }

}
