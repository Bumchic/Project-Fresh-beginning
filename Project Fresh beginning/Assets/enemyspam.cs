using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspam : MonoBehaviour
{
    [SerializeField] private float spawmrate = 1f;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private bool canspawm = true;
    public Transform mainchar;
    [SerializeField]
    private float spawnDistance = 5f;


    private void Start()
    {
        StartCoroutine(spawmer());
    }
   
    private IEnumerator spawmer()
    {
        WaitForSeconds wait = new WaitForSeconds(spawmrate);
        Vector3 viewportMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 viewportMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));


        // Generate random viewport coordinates
        float randomX = Random.Range(viewportMin.x, viewportMax.x);
        float randomY = Random.Range(viewportMin.y, viewportMax.y);

        // Convert viewport coordinates to world space
        Vector3 spawnPosition = new Vector3(mainchar.position.x + 5, mainchar.position.y, mainchar.position.z);

        while (canspawm)
        {
            yield return wait;
            int rand = Random.Range(0, 2);
            GameObject enemytospawm = enemy[rand];
            Instantiate(enemytospawm, spawnPosition, Quaternion.identity);
        }
    }
    
}
