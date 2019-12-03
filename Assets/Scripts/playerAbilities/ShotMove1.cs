using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMove1 : ProjectileBehaviour
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        } else if (other.gameObject.CompareTag("Walls")){
            Destroy(gameObject);
        }

    }

}
