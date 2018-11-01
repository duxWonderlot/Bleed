using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomtext : MonoBehaviour {

    public Text textref;
    public string[] controls;
    public string[] cards;
    public string[] about;
    // Use this for initialization
    void Start () {

        textref.text = "";
	}
	
	// Update is called once per frame
	void LateUpdate () {

        textref.text = ">" + controls[Random.Range(0, 5)] ;
        textref.text = ">" + about[Random.Range(0, 11)];
        textref.text = ">" + cards[Random.Range(0, 9)];

    }
}
