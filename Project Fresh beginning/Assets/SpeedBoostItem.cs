using System.Collections;
using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostDuration = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
               
                player.runningState.ActivateSpeedBoost();

                StartCoroutine(DeactivateBoostAfterTime(player));
            }
        }
    }

    private IEnumerator DeactivateBoostAfterTime(Player player)
    {
        yield return new WaitForSeconds(boostDuration);
        player.runningState.DeactivateSpeedBoost();
        Destroy(gameObject); 
    }
}
