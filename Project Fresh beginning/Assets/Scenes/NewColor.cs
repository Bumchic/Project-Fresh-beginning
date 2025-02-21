using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewColor : MonoBehaviour
{
    // Start is called before the first frame update
    public Color Newcolor;
    private SpriteRenderer rend;
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
        rend.color = Newcolor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
