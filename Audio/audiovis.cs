using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiovis : MonoBehaviour {




    // in this following Script you get spectrum data from audio source then apply does values to mesh which gives you some scaling value to the game 
    // in this scipt getting Spectrum data and rms values are most importent key component 
    // there are two options in this script you can make line visualizer or other shaped visaulizer like square or circle
    //things to remember in this are you have to give the audio soure to the script before you execute the scirpt , audio source can be to same object or different object but it takes priority object voice first then secone voice etc
    // Where this is used 
    //this is used in SFX and Audio of the Game!

    private const int SAMPLE_SIZE = 1024;

     
    //public GameObject totheobj;
    public float rmsvalue;
    public float dbvalue;
    public float maxvisualscale = 25.0f;

    public float bgintensity;
    //public Material bgmat;
    public Color min;
    public Color max;

    public float visualMod = 50.0f;
    public float smoothSpeed = 10.0f;
    public float keepPrecentage = 0.5f;

    public AudioSource soruce;
    private float[] samples;
    private float[] spectrum;
    private float sampleRate;
    public float pitchvalue;
    public GameObject go;
    public Transform []spawn;
    public int averagesizevalue;


    private Transform[] visaulList;
    private float[] visaulScale;
    private int amountVisual = 1;
  

    private void Start() {


       // soruce =  FindObjectOfType<AudioSource>();
        samples = new float[SAMPLE_SIZE];
        spectrum = new float[SAMPLE_SIZE];
        sampleRate = AudioSettings.outputSampleRate;
        //SpawnCircle();
        soruce.mute = true;

        SpawnLine(0);

    }

    private void SpawnLine(int n)
    {


        visaulScale = new float[amountVisual];
        visaulList = new Transform[amountVisual];


        for (int i = 0; i < amountVisual; i++) {
             go = Instantiate(go,spawn[n].transform.position,spawn[n].transform.rotation,spawn[n].transform.parent);
             
            //go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;

            // go = Instantiate(go, go.transform.position, go.transform.rotation);
            //totheobj.transform.position = new Vector3(totheobj.transform.position.x , totheobj.transform.position.y , totheobj.transform.position.z );

          
            visaulList[i] = go.transform;

            //visaulList[i].position = Vector3.right* i ;
            this.visaulList[i].position = go.transform.position ;

           



        }




    }
    /*
    private void SpawnCircle() {



        visaulScale = new float[amountVisual];
        visaulList = new Transform[amountVisual];

        Vector3 center = Vector3.zero;
        float radius = 18.0f;

        for (int i = 0; i < amountVisual; i++) {


            float ang = i * 1.0f / amountVisual;
            ang = ang * Mathf.PI * 2;

            float x = center.x + Mathf.Cos(ang) * radius;
            float y = center.y + Mathf.Sin(ang) * radius;


            Vector3 pos = center + new Vector3(x, 0, y);

            // go = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
            go = Instantiate(go);
            go.transform.localScale = new Vector3(0, 20.0f, 0);
            go.transform.position = pos;
            go.transform.rotation = Quaternion.LookRotation(Vector3.left, pos);
            go.GetComponent<Renderer>().material.color = Color.white;
            go.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            go.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);

            if (Input.GetKeyDown(KeyCode.E))
            {



                go.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);


            }



            visaulList[i] = go.transform;
        }





    }

    */
    private void Update() {



        AnalyzeSound();
        UpdateVisual();
        UpdateColor();

     

    }

    private void UpdateVisual()
    {


        int visualIndex = 0;
        int specrumIndex = 0;
        int avaerageSize = (int)(SAMPLE_SIZE * keepPrecentage / amountVisual);
        //averagesizevalue = avaerageSize;

        while (visualIndex < amountVisual)
        {


            int j = 0;
            float sum = 0;
            while (j < avaerageSize)
            {
                sum += spectrum[specrumIndex];
                specrumIndex++;
                j++;


            }


            float scaleY = sum / avaerageSize * visualMod;
            visaulScale[visualIndex] -= Time.deltaTime * smoothSpeed;

            if (visaulScale[visualIndex] < scaleY)

                visaulScale[visualIndex] = scaleY;

            if (visaulScale[visualIndex] > maxvisualscale)
                visaulScale[visualIndex] = maxvisualscale;

            Vector3 newscaleforline = new Vector3(2, 10, 10);
             

            visaulList[visualIndex].localScale = Vector3.one + newscaleforline* visaulScale[visualIndex];
            visualIndex++;

        }



    }


    private void UpdateColor() {

        bgintensity -= Time.deltaTime * smoothSpeed;

        if (bgintensity < dbvalue /20)
            bgintensity = dbvalue /20;


    }




    private void AnalyzeSound() {


        soruce.GetOutputData(samples, 0);

        int i = 0;
        float sum = 0;

        for (i = 0; i < SAMPLE_SIZE; i++) {


            sum += samples[i] * samples[i];



        }

        rmsvalue = Mathf.Sqrt(sum / SAMPLE_SIZE);

        //get dbvalue
        dbvalue = 20 * Mathf.Log10(rmsvalue / 0.1f);




        //get sound spectrumm

        soruce.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);    // this is the main part of the program 



        //Find pitch

        float maxv = 0;
        var maxN = 0;


        for (i = 0; i < SAMPLE_SIZE; i++) {


            if(!(spectrum[i] > maxv) || !(spectrum[i] > 0.01f))
            {


                continue;


                maxv = spectrum[i];
                maxN = i;

            }


            float freqN = maxN;

            if (maxN > 0 && maxN < SAMPLE_SIZE - 1) {


                var dL = spectrum[maxN - 1] / spectrum[maxN];
                var dr = spectrum[maxN - 1] / spectrum[maxN];
                freqN += 0.5f* (dr * dr - dL * dL);

            }


            pitchvalue = freqN * (sampleRate / 2) / SAMPLE_SIZE;
            
        }



    }



}
