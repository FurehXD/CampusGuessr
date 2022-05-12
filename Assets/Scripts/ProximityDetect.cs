//This script is a simple detection for when the pin is on the destination area.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetect : MonoBehaviour
{
    //If pin is in the proximity of destination
    public static bool PerfectPin = false; //If the pin is on the exact location where the destination is
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        PerfectPin = true;
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        PerfectPin = false;
    }
}
