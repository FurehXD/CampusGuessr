//This script is a simple pin placement script. When the player touches an area in the map, it places a "pin" on the map. 
//Also displays the touch positions for testing purposes


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPress : MonoBehaviour
{
    public Text text_1;
    public Text DistanceOfPin; 
    public GameObject pin;
    public static bool isPinSpawned = false;
    public Camera testcam;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //Changes the pin status to true meaning it exists in the map
            if(isPinSpawned == false)
            {
                isPinSpawned = true;
            }
            else if(isPinSpawned == true)
            {
                if(touch.phase == TouchPhase.Began)
                {
                    for (var i = 0; i < Input.touchCount; i++)
                    {
                        if (Input.GetTouch(i).phase == TouchPhase.Began)
                        {
                            var worldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                            pin.transform.position = new Vector3(worldPosition.x,worldPosition.y,0);
                            text_1.text = "Touch Position : " + worldPosition;

                        }
                    }       
                }
            }
        }
        else
        {
            text_1.text = "No touch contacts";
        }
    }
}
