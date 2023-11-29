using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cableBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newObject;
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Fire()
    {
        // MUST BE SPAWNED AT 0,0,0!!
        newObject.transform.position = Vector3.zero;
        Instantiate( newObject ); 
    }
}
