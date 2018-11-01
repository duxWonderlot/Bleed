using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenS : MonoBehaviour {

    /// <summary>
    /// the random dungoen is generated but we need (start) and (end point) with (collectables for each dungeon)
    /// </summary>




    [System.Serializable]
    public class Cells
    {



        public bool visited;
        public GameObject north;   //1
        public GameObject east; // 2
        public GameObject west; // 3
        public GameObject south; // 4






    }






    public GameObject walls , floor;
    public Transform spawnplayer;
    public float walllength =1.0f;
    public int xsize = 5;
    public int ysize = 5;
    private Vector3 intialpos;
    private GameObject wallholder;
    private Cells[] cel;
    private int currentcell = 0;
    private int totalcells;
    private int visitedcells = 0;
    private bool startedbuilding = false;
    private int currentNeighbour = 0;
    private List<int> lastcells;
    private int backingup = 0;
    private int walltobreak = 0;
    public Camerafollow sprt;
    private Transform tempplayer;
    private Vector3 mypos;
    void Awake() {


        CreateWalls();
        this.sprt.GetComponent<Camerafollow>().player.transform.position = tempplayer.transform.position;


    }

    void Update()
    {


        sprt.GetComponent<Camerafollow>().player.transform.position = tempplayer.transform.position;


    }


    void CreateWalls() {




       

        wallholder = new GameObject();
        wallholder.name = "MapGenS";
        intialpos = new Vector3((-xsize / 2) + walllength/2, 0 ,(-ysize/2)+ walllength/2 );
        mypos = intialpos;
        GameObject tempwall , tempfloor;

        // for walls
        //Forloop xaxis
        tempplayer = Instantiate(spawnplayer, mypos, Quaternion.identity);
        // this is to spawn the player with camfollow//




        // up to there//

        for (int i = 0; i < ysize; i++) {

            for (int j = 0; j <= xsize; j++) {


                mypos = new Vector3(intialpos.x + (j*walllength)-walllength/2, 0.0f , intialpos.z+(i*walllength)-walllength/2);
                tempwall =Instantiate(walls, mypos, Quaternion.identity) as GameObject;

                tempwall.transform.parent = wallholder.transform;




            }



        }


        //for yaxis
        for (int i = 0; i <= ysize; i++)
        {

            for (int j = 0; j < xsize; j++)
            {


                mypos = new Vector3(intialpos.x + (j * walllength)  , 0.0f, intialpos.z + (i * walllength) - walllength );
                tempwall = Instantiate(walls, mypos, Quaternion.Euler(0.0f,90.0f,0.0f)) as GameObject;
                tempwall.transform.parent = wallholder.transform;



            }



        }

        // for floors

        for (int i = 0; i < ysize; i++)
        {

            for (int j = 0; j < xsize; j++)
            {


                mypos = new Vector3(intialpos.x + (j * walllength), -0.9f, intialpos.z + (i * walllength) - walllength/2);
                tempfloor = Instantiate(floor, mypos, Quaternion.Euler(0.0f, 90.0f, 0.0f)) as GameObject;
                tempfloor.transform.parent = wallholder.transform;



            }



        }


       


        Createcells();
        //tempplayer = Instantiate(spawnplayer, mypos, Quaternion.identity);


    }
    void Createcells()
    {

        lastcells = new List<int>();
        lastcells.Clear();
        totalcells = xsize * ysize;
        GameObject[] allwalls;
        int childen = wallholder.transform.childCount;
        allwalls = new GameObject[childen];
        cel = new Cells[xsize * ysize];
        int eastwestprocess = 0;
        int childProcess = 0;
        int termCount = 0;
        //Get all children
       
        for (int i =0; i<childen; i++) {

            allwalls[i] = wallholder.transform.GetChild(i).gameObject;


        }

        //Assgin walls to the walls

        for (int cellprocess = 0; cellprocess < cel.Length; cellprocess++) {

            if (termCount == xsize)     // walls missmatch fix
            {

                eastwestprocess ++;
                termCount = 0;


            }

            cel[cellprocess] = new Cells();
            cel[cellprocess].east = allwalls[eastwestprocess];

            cel[cellprocess].south = allwalls[childProcess+(xsize+1)*ysize];
            
            eastwestprocess++;

            termCount++;
            childProcess++;
            cel[cellprocess].west = allwalls[eastwestprocess];
            cel[cellprocess].north = allwalls[(childProcess + (xsize + 1) * ysize)+xsize -1];

            
        }

        CreateMaze();   // this should be outside the forloop
       
    }
    void CreateMaze() {

       

        if (visitedcells < totalcells) {

            if (startedbuilding)
            {

                GivemeNightbor();
                 

                if (cel[currentNeighbour].visited == false && cel[currentcell].visited == true) {

                    Breakwall();

                    cel[currentNeighbour].visited = true;
                    visitedcells++;
                    lastcells.Add(currentcell);
                    currentcell = currentNeighbour;
                    if (lastcells.Count > 0) {

                        backingup = lastcells.Count - 1;

                    }


                }

            }
            else {

                currentcell = Random.Range(0, totalcells);
                cel[currentcell].visited = true;
                visitedcells++;
                startedbuilding = true;

            }

            Invoke("CreateMaze", 0.0f);
        
            print("dungouen gen finised");
        }



    }
    void Breakwall() {

       
        switch (walltobreak) {

            case 1: Destroy(cel[currentcell].north); break;
            case 2: Destroy(cel[currentcell].east); break;
            case 3: Destroy(cel[currentcell].west); break;
            case 4: Destroy(cel[currentcell].south); break;
            





        }






    }
    void GivemeNightbor() {




       

        totalcells = xsize * ysize;
        int length = 0;
        int[] neighbours = new int[4];
        int[] connectingwall = new int[4];
        int check = 0;
        check = (currentcell + 1) / xsize;
        check -= 1;
        check *= xsize;
        check += xsize;
        //west 

        if (currentcell + 1 < totalcells && (currentcell)!= check) {

            if (cel[currentcell + 1].visited == false) {

                neighbours[length] = currentcell + 1;
                connectingwall[length] = 3;
                length++;


            }

        }


        //east

        if (currentcell + 1 >= 0 && currentcell != check)
        {

            if (cel[currentcell - 1].visited == false)
            {

                neighbours[length] = currentcell - 1;
                connectingwall[length] = 2;
                length++;


            }

        }


        //north

        if (currentcell + xsize < totalcells)
        {

            if (cel[currentcell + xsize].visited == false)
            {

                neighbours[length] = currentcell + xsize;
                connectingwall[length] = 1;

                length++;


            }

        }

        //south

        if (currentcell - xsize >= 0)
        {

            if (cel[currentcell - xsize].visited == false)
            {

                neighbours[length] = currentcell - xsize;

                connectingwall[length] = 4;

                length++;


            }
            

        }


        if (length != 0)
        {

            int thechosenone = Random.Range(0, length);
            currentNeighbour = neighbours[thechosenone];

            walltobreak = connectingwall[thechosenone];

        }
        else {

            if (backingup > 0) {

                currentcell = lastcells[backingup];

                backingup--;


            }



        }
      


    }
   

}
