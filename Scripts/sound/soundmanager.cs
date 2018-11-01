using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour {

    public static AudioClip deathsod, shootingsod;
    public static AudioSource audioSrc;




    void Start() {


        deathsod = Resources.Load<AudioClip>("destroy");
        shootingsod = Resources.Load<AudioClip>("shooting");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip) {


        switch (clip) {


            case "shot":
                audioSrc.PlayOneShot(shootingsod ,1);
                break;

            case "kill":
                audioSrc.PlayOneShot(deathsod , 1);
                break;



        }




    }
}
