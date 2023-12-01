using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cableBoxScript : MonoBehaviour
{
    public GameObject newObject;

    // Run when Object is fired
    public void Fire()
    {
        // Spawns at spawner Object
        newObject.transform.position = Vector3.zero;
        Instantiate( newObject ); 
    }
}
