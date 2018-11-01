using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playermovement : MonoBehaviour {


    //this is playermovement script where camerafollow , exp , gravity , powers , speed of the player , bulletypes spawn is allpied to this gameobject
    // and yes this is a prefab for reusing it, 


    // player movement 
    public float Speed = 10f, _distance = 2.0f, _height = 10.0f;
    private Vector3 newmove, moveveloctiy;
    private Rigidbody rb;
    public Camera cam;
    public int newhealth = 5;
    public int newpower ;
    public float nht;
    public Slider health , power;
    public GameObject Teleport1;
    public GameObject deathanim;
    //---------------------------//  gameover variables
    public Text gameover;
    public GameObject canvaselement;
    private Scene scene;
    private bool istrue = false;
    //----------------------------//
    public exp exprefforscore;
    private float verticalvelocity;
    private float gravty = 14.0f;
    // Use this for initialization
    void Start () {

        istrue = false;
        this.rb = GetComponent<Rigidbody>();

        scene = SceneManager.GetActiveScene();
        cam = FindObjectOfType<Camera>();
       nht = health.maxValue = 100;
        exprefforscore = FindObjectOfType<exp>();

        canvaselement.SetActive(false);
        gameover.text = PlayerPrefs.GetInt("HighScore").ToString();

    }

    // Update is called once per frame
    void FixedUpdate() {                                     //fixed update is used for physics objects (for optimization purposes)

         
        

            if (Input.GetKey(KeyCode.R))
            {


                SceneManager.LoadScene(scene.name);

            }


         


        if (cam) {



            newmove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            moveveloctiy = newmove * Speed;

            Ray camray = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float raylength;

            if (groundPlane.Raycast(camray, out raylength))
            {


                Vector3 pointtolook = camray.GetPoint(raylength);



                Debug.DrawLine(camray.origin, pointtolook, Color.grey);

                transform.LookAt(new Vector3(pointtolook.x, transform.position.y, pointtolook.z));

            }

            rb.velocity = moveveloctiy;


        }

        if (!cam) {
            return;

        }






      



    }



  

    void OnCollisionEnter(Collision col)                 // here you apply collision for your bullet and enemy bullets where both the objects harm you if you got shot!
    {

        if (col.gameObject.tag == "bullet") {



            soundmanager.PlaySound("kill");
            health.value = health.value - newhealth;
            Debug.Log(health.value);


            if (health.value == 0) {

                soundmanager.PlaySound("kill");
                print("you died!!!");
                Destroy(this.gameObject);
                canvaselement.SetActive(true);
                
                if (exprefforscore.levelcount > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", exprefforscore.levelcount);
                    gameover.text = "HighScore " +":" +exprefforscore.levelcount.ToString();
                }
                var newrep = Instantiate(deathanim, transform.position, transform.rotation);
             
                Destroy(newrep, 3.0f);
                

            }


        }


        if (col.gameObject.tag == "enemybul")
        {

            soundmanager.PlaySound("kill");
            health.value = health.value - newhealth;
            Debug.Log(health.value);


            if (health.value == 0)
            {

                soundmanager.PlaySound("kill");
                Destroy(this.gameObject);
                canvaselement.SetActive(true);
                //gameover.text = "Your Score" +":"+ exprefforscore.leveltext.text;
                if (exprefforscore.levelcount > PlayerPrefs.GetInt("HighScore", 0))
                {
                    PlayerPrefs.SetInt("HighScore", exprefforscore.levelcount);
                    gameover.text = "HighScore " + ":" + exprefforscore.levelcount.ToString();
                }
                print("you died!!!");
                var newrep = Instantiate(deathanim, transform.position, transform.rotation);

                Destroy(newrep, 3.0f);

                

            }



        }

        

    }

    


}

   

