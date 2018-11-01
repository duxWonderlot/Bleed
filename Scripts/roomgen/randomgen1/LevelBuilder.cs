using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    public Room startroomPrefab, endroomPrefab;
    public List<Room> roomPrefabs = new List<Room>();
    public Vector2 iterationRange = new Vector2(3, 10);

    List<Doorway> availableDorrways = new List<Doorway>();


    Startroom startroom;
    EndRoom endroom;
    List<Room> placeRooms = new List<Room>();


    LayerMask roomlayer;

    void Start() {

        roomlayer = LayerMask.GetMask("Room");
        StartCoroutine("genlevel");

    }

    IEnumerator genlevel() {

        WaitForSeconds startup = new WaitForSeconds(1);
        WaitForFixedUpdate interval = new WaitForFixedUpdate();

        yield return startup;


        // place start room
        Placestartroom();
       // Debug.Log("Place start room");

        yield return interval;


        // Random iteration

        int iteration = Random.Range((int)iterationRange.x, (int)iterationRange.y);


        for(int i = 0;  i< iteration; i++)
        {

            //place random room
            placeRoom();
            //Debug.Log("Place random room from list");
            yield return interval;
            
        }

        // Place end room
        //Debug.Log("Place end Room");
        placeendroom();
        yield return interval;

        //level gen done!!

        Debug.Log("level gen done");

        yield return new WaitForSeconds(2000.0f);
        // Debug.Log("reset level gen");

       //resetlevelgen();  

    }


    void Placestartroom() {

        Debug.Log("Place start room");

        //Instantiate room

        startroom = Instantiate(startroomPrefab) as Startroom;
        startroom.transform.parent = this.transform;

        //get doorways from current rooms add to global doorways
        adddoorwaystolist(startroom, ref availableDorrways);

        //Position room
        startroom.transform.position = Vector3.zero;
        startroom.transform.rotation = Quaternion.identity;
        

    }
    void adddoorwaystolist(Room room , ref List<Doorway> list) {


        foreach (Doorway doorway in room.doorways) {

            int r = Random.Range(0, list.Count);
            list.Insert(r, doorway);




        }




    }

    void placeRoom() {


        Debug.Log("Place random room from list");

        //Instatiate room

        Room currentRoom = Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]) as Room;
        currentRoom.transform.parent = this.transform;

        //Create doorway lists to loop over

        List<Doorway> allAvailableDoorways = new List<Doorway>(availableDorrways);
        List<Doorway> currentroomDoorways = new List<Doorway>();
        adddoorwaystolist(currentRoom, ref currentroomDoorways);

        // get doorways from currentroom and add them randomly to the list of ava doorways 

        adddoorwaystolist(currentRoom, ref availableDorrways);


        bool roomplace = false;

        foreach (Doorway availabeDoorway in allAvailableDoorways) {


            foreach (Doorway currentdoorway in currentroomDoorways)
            {
                //position room

                Positionroomatdoorways(ref currentRoom, currentdoorway, availabeDoorway);

                //chackroom overlaps
                if (CheckRoomOverlap(currentRoom)) {

                    continue;

                }

                roomplace = true;

                // Add room to list

                placeRooms.Add(currentRoom);

                // Remove occupied doorways

                currentdoorway.gameObject.SetActive(false);
                availableDorrways.Remove(currentdoorway);



                availabeDoorway.gameObject.SetActive(false);
                availableDorrways.Remove(availabeDoorway);


                // Exit loop if room has been place
                break;

            }
            if (roomplace) {


                break;

            }


        }

        //Room couldnt be place Restrt the level and try again

        if (!roomplace) { 

           // Destroy(currentRoom.gameObject);
            //resetlevelgen();

        }



    }

    void Positionroomatdoorways(ref Room room , Doorway roomDoorway ,Doorway targetDoorway) {

        //rest room position and rotation
        room.transform.position = Vector3.zero;
        room.transform.rotation = Quaternion.identity;



        // rotate room to match previous doorways orients

        Vector3 targetDoorwayEular = targetDoorway.transform.eulerAngles;
        Vector3 roomDoorwaysEular = roomDoorway.transform.eulerAngles;
        float deltaAngle = Mathf.DeltaAngle(roomDoorwaysEular.y, targetDoorwayEular.y);
        Quaternion currentRoomTargetRotation = Quaternion.AngleAxis(deltaAngle, Vector3.up);

        room.transform.rotation = currentRoomTargetRotation * Quaternion.Euler(0, 100f, 0);

        //Position room
        Vector3 roomPositionOffset = roomDoorway.transform.position - room.transform.position;
        room.transform.position = targetDoorway.transform.position - roomPositionOffset;




    }

    bool CheckRoomOverlap(Room room) {


        Bounds bounds = room.RoomBounds;
        bounds.Expand(-0.1f);

        Collider[] colliders = Physics.OverlapBox(bounds.center, bounds.size / 2, room.transform.rotation, roomlayer);

        if (colliders.Length > 0) {
            //ignor collision with current room

            foreach (Collider c in colliders) {

                if (c.transform.parent.gameObject.Equals(room.gameObject))
                {
                        continue;
                } else
                {

                    Debug.LogError("Overlap detection");
                    return true;
                  }
            }



      }

        return false;

}



    void placeendroom()
    {

        Debug.Log("Place end Room");



    }

    void resetlevelgen()
    {


        Debug.LogError("reset level gen");



        StopCoroutine("genlevel");
        if (startroom)
        {


            Destroy(startroom.gameObject);

        }

        if (endroom)
        {


            Destroy(endroom.gameObject);


        }

        foreach (Room room in placeRooms)
        {


            Destroy(room.gameObject);


        }
        //claer lists
        placeRooms.Clear();
        availableDorrways.Clear();

        StartCoroutine("genlevel");

    }




}





