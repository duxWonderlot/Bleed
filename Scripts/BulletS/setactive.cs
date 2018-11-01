using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setactive : MonoBehaviour {


    // watch out for pull radius when you increase object size
    public float PullRadius; // Radius to pull
    public float GravitationalPull; // Pull force
    public float MinRadius; // Minimum distance to pull from
    public float DistanceMultiplier; // Factor by which the distance affects force
    public bool defectbul = false , setact = false;
    public GameObject pa;
    public Playermovement psref; 

    public LayerMask LayersToPull;


    void Awake() {

        defectbul = false;
        setact = false;
        pa.SetActive(false);
        psref = FindObjectOfType<Playermovement>();
    }
    // Function that runs on every physics frame
    void FixedUpdate()
    {

        print(defectbul);
        if (setact)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                psref.power.value -= 20;
                defectbul = true;
              
                pa.SetActive(true);

            }
            else if (Input.GetKeyUp(KeyCode.E))
            {


                defectbul = false;
                pa.SetActive(false);

            }
            


            

            if (defectbul == true)
            {

                Collider[] colliders = Physics.OverlapSphere(transform.position, PullRadius, LayersToPull);

                foreach (var collider in colliders)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();

                    if (rb == null) continue; // Can only pull objects with Rigidbody

                    Vector3 direction = transform.position - collider.transform.position;

                    if (direction.magnitude < MinRadius) continue;

                    float distance = direction.sqrMagnitude * DistanceMultiplier + 1; // The distance formula

                    // Object mass also affects the gravitational pull
                    rb.AddForce(direction.normalized * (GravitationalPull / distance) * rb.mass * Time.fixedDeltaTime);



                }

            }
            if (psref.power.value == 0) {

                defectbul = false;


            }
        }

       


    }

/*
    void OnDrawGizmos()
    {

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(this.transform.position, PullRadius);

    }
    */
}

