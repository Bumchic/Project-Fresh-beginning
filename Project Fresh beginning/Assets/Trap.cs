using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject gameOverObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Characters"))
        {
            collision.gameObject.SetActive(false);
            gameOverObject.SetActive(true);
        }
    }
}
