using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Votan : MonoBehaviour
{
    public Transform MainCam;
    public Transform map1;
    public Transform map2;
    public float length;

   
    void Update()
    {
        // Check if MainCam is to the right of map1
        if (MainCam.position.x > map1.position.x)
        {
            UpdateMapPosition(Vector3.right);
        }
        else if (MainCam.position.x < map1.position.x) // MainCam is to the left of map1
        {
            UpdateMapPosition(Vector3.left);
        }
    }

    void UpdateMapPosition(Vector3 direction)
    {
        map2.position = map1.position + direction * length;
        Transform temp = map1;
        map1 = map2;
        map2 = temp;
    }
}
