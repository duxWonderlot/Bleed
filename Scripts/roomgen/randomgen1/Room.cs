using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public Doorway[] doorways;
    public MeshCollider meshcollider;

    public Bounds RoomBounds {


        get { return meshcollider.bounds;}

    }
}
