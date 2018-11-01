using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carddrag : MonoBehaviour {
    
    float offsetx;
    float offsety;

    
     
    public void BeginDrag()
    {

        offsetx = transform.position.x - Input.mousePosition.x;
        offsety = transform.position.y - Input.mousePosition.y;

    }
    public void OnDrag()
    {

        transform.position = new Vector3(offsetx +Input.mousePosition.x, offsety+ Input.mousePosition.y);

    }
    
    




}
