using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class votan : MonoBehaviour
{
    public Transform MainCam;
    public Transform map1;
    public Transform map2;
    public float length;

    // Update is called once per frame
    void Update()
    {
        // Check if MainCam is to the right of map1
        if (MainCam.position.x > map1.position.x)
        {
            update(Vector3.right);

        }
        else if (MainCam.position.x < map1.position.x) // MainCam is to the left of map1
        {
            update(Vector3.left); // Always move map1 to the left (redundant)
        }
    }

    void update(Vector3 direction)
    {
        map2.position = map1.position + direction * length; // Update map2 position
        Transform temp = map1;  // Store map1 in a temporary variable
        map1 = map2;           // Swap map1 and map2 references
        map2 = temp;           // Restore map2 reference from temporary variable
    }
}