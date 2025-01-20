using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIScript: MonoBehaviour
{
    public Slider sliderUI;
    public Image FillBackGround;
    public Transform Target;
    public UnityEngine.Object grunt;
    private Grunt gruntScript;
    public Vector3 Offset;

    public void Awake()
    {
        gruntScript = grunt.GetComponent<Grunt>();
        Target = grunt.GetComponent<Transform>();
        transform.position = Target.position + Offset;
    }

    public void Update()
    {
        UpdateHealth(gruntScript.health.currentHealth);
    }
    public void UpdateHealth(float health)
    {   
        sliderUI.value = health;
    }
    
}
