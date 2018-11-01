using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forallbullets : MonoBehaviour
{

    // this take cares bullethit to enemies to apply this script you have to make empty gameobject
    // then use this script to the object then assign needed scripts then it works as it should!

    public enemy en;
    public enemy1 en1;
    public enemy2 en2;
    public Boss bos;
    public int amountofloss = 10;

    // Use this for initialization
    void Start()
    {
        
        en = FindObjectOfType<enemy>();
        en1 = FindObjectOfType<enemy1>();
        en2 = FindObjectOfType<enemy2>();
        bos = FindObjectOfType<Boss>();


    }


    void hidebullets()
    {


        gameObject.SetActive(false);


    }

    private void OnEnable()     // these are used for object pooling
    {
        transform.GetComponent<Rigidbody>().WakeUp();
        Invoke("hidebullets", 2.5f);
        
    }


    private void OnDisable()
    {
        CancelInvoke();
        transform.GetComponent<Rigidbody>().Sleep();
        

    }

    // Update is called once per frame
    void Update()
    {


    }


    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "boss")
        {

            
            bos.enemyh -= amountofloss;
           

        }
        if (col.gameObject.tag == "en")
        {

           
            en.enemyh -= amountofloss;
            en1.enemyh -= amountofloss;
            en2.enemyh -= amountofloss;

        }
    }
}
