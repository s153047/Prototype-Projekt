using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShotBehaviour : EnemyProjectileBehaviour
{
    // Start is called before the first frame update
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if
          (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
