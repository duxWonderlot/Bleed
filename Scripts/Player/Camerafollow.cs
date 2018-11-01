using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{


    #region reference
    public Transform player;       //Public variable to store a reference to the player game object
   // private Vector3 playerpos;

    public Vector3 offset;         //Private variable to store the offset distance between the player and camera
    #endregion
    // Use this for initialization
    void Awake()
    {


        player = GameObject.FindGameObjectWithTag("Player").transform;
        this.transform.position = player.transform.position + offset;
        //this.transform.position = this.player.transform.position;
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
       // playerpos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.

        if (player)
        {
            this.transform.position = player.transform.position + offset;
        }

        if (!player) {

            return;
        }
    }

}
