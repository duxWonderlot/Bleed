using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene1 : MonoBehaviour {

    public void Sceneload(int seneno) {


        AsyncOperation Ope = SceneManager.LoadSceneAsync(seneno);

        
    }


   


    public void quit() {

        Application.Quit();

    }
}
