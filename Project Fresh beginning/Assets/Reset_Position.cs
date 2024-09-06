using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Reset_Position : MonoBehaviour
{
    public Movement_script movement_script;

    void Start()
    {
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
          movement_script.Body.position = new Vector2(-2.152681f, -1.289194f);
        }
    }
}
