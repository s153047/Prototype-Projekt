using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCollectible : MonoBehaviour
{
    public int manaAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.ChangeMana(manaAmount);
            Destroy(gameObject);
        }
    }
}
