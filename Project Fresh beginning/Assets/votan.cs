using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class votan : MonoBehaviour
{
    public Transform MainCam;
    public Transform midbackground;
    public Transform sidebackground;
    public float length;
   

    // Update is called once per frame
    void Update()
    {
        if ( MainCam.position.x> midbackground.position.x)
        {
            update(Vector3.right);
        }
        else if (MainCam.position.x < midbackground.position.x)
        {
            update(Vector3.left);
        }
    }
    void update (Vector3 direction)
    {
        sidebackground.position = midbackground.position * length;
        Transform temp = midbackground;
        midbackground = sidebackground;
        sidebackground = temp;
    }
}
