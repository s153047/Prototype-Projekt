using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCollectible : MonoBehaviour
{
    public float manaMultiplier;
    public float buffTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            if (player.ManaBuff(manaMultiplier, buffTime))
            {
                Destroy(gameObject);
            }
        }
    }
}
